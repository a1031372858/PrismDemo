using System;
using Common.Enums;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Common.WebDto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlData.Beans;

namespace Service
{
    public class ServiceBase
    {

        protected string Host { get; set; } = "127.0.01";

        protected int Port { get; set; } = 80;

        protected string Account { get; set; }

        protected string Password { get; set; }


        protected int JavaPort { get; set; } = 80;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramMap">参数</param>
        /// <param name="callerName">方法名</param>
        /// <returns></returns>
        public async Task<T> SendRequest<T>(Dictionary<string, string> paramMap, [CallerMemberName] string callerName = "")
        {
            var path = string.Empty;
            var requestMethod = Constants.RequestMethod.GET;
            //拿到发送请求的方法，根据方法获取特性

            var typeList = new List<Type>();
            if (paramMap != null && paramMap.Count > 0)
            {
                for (int i = 0; i < paramMap.Count; i++)
                {
                    typeList.Add(typeof(string));
                }
            }

            var method = GetType().GetMethod(callerName, typeList.ToArray());
            if (method == null) return default;

            var pathAttribute = method.GetCustomAttributes(typeof(PathAttribute), true).Cast<PathAttribute>().FirstOrDefault();
            // var paramList = method.GetParameters();
            // Dictionary<string, string> paramDic = new Dictionary<string, string>();

            if (pathAttribute != null)
            {
                //从特性中找到路径
                path = pathAttribute.Path;
                requestMethod = pathAttribute.Method;
            }
            var result = await SendRequestBase<T>(requestMethod, paramMap, path);
            return result;
        }

        private async Task<T> SendRequestBase<T>(Constants.RequestMethod requestMethod, Dictionary<string, string> paramMap, string path = "")
        {
            

            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;
            try
            {
                switch (requestMethod)
                {
                    case Constants.RequestMethod.GET:
                        var getParams = MakeParams(paramMap);
                        var getUriBuilder = new UriBuilder(Uri.UriSchemeHttp, Host, Port, path, getParams);
                        response = await client.GetAsync(getUriBuilder.Uri);
                        break;
                    case Constants.RequestMethod.POST:
                        var postParams = MakePostParams(paramMap);
                        var uriBuilder = new UriBuilder(Uri.UriSchemeHttp, Host, Port, path);
                        response = await client.PostAsync(uriBuilder.Uri, postParams);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                var responseWebDto = JsonConvert.DeserializeObject<ResponseWebDto>(content);
                Console.WriteLine(responseWebDto?.Status);
                Console.WriteLine(ResponseStatus.Success.GetCode());
                if (responseWebDto != null )
                {
                    var json =(JObject)JsonConvert.DeserializeObject(responseWebDto.ResponseContent.ToString());
                    var json2 = new JObject();
                    foreach (var item in json)
                    {
                        if (item.Key.Length > 0)
                        {
                            json2.Add($"{item.Key.Substring(0, 1).ToUpper()}{item.Key.Substring(1, item.Key.Length - 1)}", item.Value);
                        }
                    }

                    var result =json2.ToObject<T>();
                    return default;
                }
            }

            return default;
        }


        private string MakeParams(Dictionary<string, string> paramMap)
        {
            if (paramMap == null || paramMap.Count <= 0) return string.Empty;
            var httpParam = "?";
            var isInit = true;
            foreach (var param in paramMap)
            {
                if (!isInit)
                {
                    httpParam += "&";
                }
                else
                {
                    isInit = false;
                }
                httpParam += $"{param.Key}={param.Value}";
            }

            return httpParam;
        }


        private MultipartFormDataContent MakePostParams(Dictionary<string, string> paramMap)
        {
            var formData = new MultipartFormDataContent();
            if (paramMap == null) return formData;

            foreach (var param in paramMap)
            {
                formData.Add(new StringContent(param.Value), param.Key);
            }

            return formData;
        }
    }
}