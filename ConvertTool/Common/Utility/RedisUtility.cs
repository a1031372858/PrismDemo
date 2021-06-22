using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Documents;
using Microsoft.Practices.ServiceLocation;
using Prism.Ioc;
using ServiceStack.Common.Extensions;
using ServiceStack.Redis;
using SqlData;
using SqlData.Beans;

namespace Common.Utility
{
    public class RedisUtility
    {
        public static RedisClient Client = new RedisClient("127.0.0.1",6379);

        public static void LoadInitData()
        {

            var container = ServiceLocator.Current.GetInstance<IContainerProvider>();
            var sqlContext = container?.Resolve<PostgreSqlContext>();
            var userList=new List<UserDetail>();
            try
            {
                userList = sqlContext?.UserDetail.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (userList != null)
            {
                foreach (var item in userList.Where(item => !Client.ContainsKey(item.Phone)))
                {
                    Client.Set(item.Phone, item);
                }
            }
        }
    }
}