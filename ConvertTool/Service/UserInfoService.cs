using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using SqlData.Beans;

namespace Service
{
    public class UserInfoService : ServiceBase
    {

        [Path("login.action", Constants.RequestMethod.POST)]
        public async Task<UserDetail> SelectUserInfo(string phone,string userPassword)
        {
            Dictionary<string, string> paramDic = new Dictionary<string, string>
            {
                {nameof(phone), phone}, {nameof(userPassword), userPassword}
            };
            return await SendRequest<UserDetail>(paramDic);
        }



        // [Path("postLogin.action", Constants.RequestMethod.POST)]
        // public async Task<UserDetail> SelectUserInfo(string phone)
        // {
        //     Dictionary<string, string> paramDic = new Dictionary<string, string>
        //     {
        //         {nameof(phone), phone}, 
        //     };
        //
        //     return await SendRequest<UserDetail>(paramDic);
        // }
    }
}
