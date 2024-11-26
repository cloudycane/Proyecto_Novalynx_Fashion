using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NovalynxFashion.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string DisplayName(this Enum value)
        {
            Type enumType = value.GetType();
            string enumValue = Enum.GetName(enumType, value);
            if (enumValue == null)
            {
                return value.ToString(); 
            }

            MemberInfo member = enumType.GetMember(enumValue)[0];

           
            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);

           
            if (attrs.Length > 0)
            {
                var displayAttribute = (DisplayAttribute)attrs[0];
              
                if (displayAttribute.ResourceType != null)
                {
                    return displayAttribute.GetName();
                }
                return displayAttribute.Name;
            }

      
            return value.ToString();
        }
    }
}
