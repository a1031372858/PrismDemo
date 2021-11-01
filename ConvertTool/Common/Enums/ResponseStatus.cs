using static Common.Enums.EnumExtension;

namespace Common.Enums
{
    public enum ResponseStatus
    {
        [Code("200"), Description("成功")] 
        Success =200,
        [Code("101"), Description("失败")]
        Failed,
    }
}