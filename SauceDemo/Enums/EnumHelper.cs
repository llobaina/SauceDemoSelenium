using System.Reflection;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace SauceDemo.Enums;
// Esta clse es para trabajar con los Enum
public static class EnumHelper
{
    //Obtener la descripción de un Enum
    public static string GetDescription(this Enum value)
    {
        FieldInfo? field = value.GetType().GetField(value.ToString());
        DescriptionAttribute? attribute = (DescriptionAttribute)
            field.GetCustomAttribute(typeof(DescriptionAttribute));
        return attribute == null ? value.ToString() : attribute.Description;
    }
    //Convertir un Enum a diccionario
    public static Dictionary<Enum, string> GetItemsAsDictionary<T>()
        where T : Enum =>
        Enum.GetValues(typeof(T))
            .Cast<T>()
            .ToDictionary(value => (Enum)value, value => value.GetDescription());

    //Convertir un string a Enum
    public static T ConvertStringToEnum<T>(string value)
        where T : struct, Enum
    {
        if (Enum.TryParse(value, true, out T result))
        {
            return result;
        }

        throw new ArgumentException($"Invalid name: {value}");
    }
}
