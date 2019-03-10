using System;
using System.ComponentModel;
using System.Linq;

namespace NewsPortal.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum source)
        {
            var enumType = source.GetType();
            var descriptionAttribute = enumType.GetField(source.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), true)
                .FirstOrDefault() as DescriptionAttribute;

            return descriptionAttribute?.Description;
        }
    }
}
