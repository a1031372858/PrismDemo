using static Common.Enums.EnumExtension;

namespace Common.Enums
{
    public class Constants
    {
        public enum LoginViewMode
        {
            [Code("0"),Description("ログイン")]
            Login =0,
            [Code("1"), Description("登録")]
            Register =1,
            [Code("2"), Description("パスワードを変更する")]
            UpdatePsw =2,
        }
    }
}