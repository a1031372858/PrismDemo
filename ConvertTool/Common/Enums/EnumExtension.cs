using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

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

            public string Code { set; get; }

            public CodeAttribute(string code)
            {
                Code = code;
            }
        }


        public sealed class DescriptionAttribute : Attribute
        {
            public string Description { set; get; }

            public DescriptionAttribute(string description)
            {
                Description = description;
            }
        }

        private static TAttribute GetAttribute<TAttribute>(this Enum value)
        {
            var enumType = value.GetType();
            var attributes = enumType.GetCustomAttributes(typeof(TAttribute), false)
                .Cast<TAttribute>().ToList();
            return attributes.FirstOrDefault();
        }

        /// <summary>
        /// Codeを取得する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetCode(this Enum value)
        {
            return value.GetAttribute<CodeAttribute>()?.Code ?? string.Empty;
        }
    }
}