using System;

namespace Common.Enums
{
    public static class EnumExtension
    {

        /// <summary>
        /// コード値に関する属性
        /// </summary>
        [AttributeUsage(AttributeTargets.Field)]
        public sealed class CodeAttribute : Attribute
        {
            public CodeAttribute(string code)
            {
                Code = code;
            }

            public string Code = "";
        }
    }
}