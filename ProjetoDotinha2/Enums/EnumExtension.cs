using System.ComponentModel;
using System.Reflection;

namespace ProjetoDotinha2.Enums
{
    public static class EnumExtension
    {
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
