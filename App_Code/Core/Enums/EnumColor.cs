using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EnumColor
/// </summary>
public enum EnumColor :int
{
    red=1,
    blue=2,
    green=3,
    yellow=4

}
public static class Enumeration//Make it in other place
{
    public static IDictionary<int, string> GetAll<TEnum>() where TEnum : struct
    {
        var enumerationType = typeof(TEnum);

        if (!enumerationType.IsEnum)
            throw new ArgumentException("Enumeration type is expected.");

        var dictionary = new Dictionary<int, string>();

        foreach (int value in Enum.GetValues(enumerationType))
        {
            var name = Enum.GetName(enumerationType, value);
            dictionary.Add(value, name);
        }

        return dictionary;
    }
}