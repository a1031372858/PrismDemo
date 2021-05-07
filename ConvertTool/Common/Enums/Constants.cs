using static Common.Enums.EnumExtension;

namespace Common.Enums
{
    public class Constants
    {
        public enum LoginViewMode
        {
            [Code("0")]
            Login=0,
            [Code("1")]
            Register =1,
            [Code("2")]
            UpdatePsw =2,
        }
    }
}