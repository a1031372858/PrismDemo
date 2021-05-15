using SqlData.Beans;

namespace Common.Global
{
    public class GlobalData
    {
        private static UserDetail _loginUserDetail;
        public static UserDetail LoginUser
        {
            set => _loginUserDetail = value;
            get
            {
                return _loginUserDetail;
            }
        }
    }
}