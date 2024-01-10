using System.ComponentModel;
using SampSharp.Entities.SAMP;

namespace Torcidas.Core.Utils
{
    public static class Extensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (field == null)
                return enumValue.ToString();

            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            return enumValue.ToString();
        }
        
        public static string ToHexColor(this Color color)
        {
            var colorString = color.ToString();
            return colorString!.Trim('{', '}');
        }
    }
}