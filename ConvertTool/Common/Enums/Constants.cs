using static Common.Enums.EnumExtension;

namespace Common.Enums
{
    public class Constants
    {
        public enum LoginViewMode
        {
            [Code("1")]
            Login=0,
            Register=1,
            UpdatePsw=2,
        }
    }
}