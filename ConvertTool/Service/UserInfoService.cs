using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserInfoService:ServiceBase
    {

        [Path("www.baidu.com")]
        public async Task SelectUserInfo(string id)
        {
            await SendRequest(new KeyValuePair<string, string>(nameof(id),id));
        }
    }
}
