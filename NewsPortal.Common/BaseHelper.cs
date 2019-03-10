using System.Linq;
using System.Reflection;

namespace NewsPortal.Common
{
    public static class BaseHelper
    {
        public static string[] GetEnumFields<TEnum>()
        {
            return typeof(TEnum)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(field => field.Name)
                .ToArray();
        }
    }
}
