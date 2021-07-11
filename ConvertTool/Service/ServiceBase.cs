using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceBase
    {
        public async Task SendRequest(KeyValuePair<string,string> param)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://www.baidu.com/");
            var content =await response.Content.ReadAsStringAsync();
        }
    }
}