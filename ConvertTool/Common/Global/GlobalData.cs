using Common.Models;
using SqlData.Beans;

namespace Common.Global
{
    public class GlobalData
    {
        private static UserInfoModel _loginUserInfo=new UserInfoModel();
        public static UserInfoModel LoginUserInfo
        {
            set => _loginUserInfo = value;
            get
            {
                return _loginUserInfo;
            }
        }
    }
}