using System;
using System.Collections.Generic;

public enum EnumColor : int
{
    White = 1,
    Yellow = 2,
    Pink = 3,
    Red = 4,
    Silver = 5,
    Gray = 6,
    Olive = 7,
    Purple = 8,
    Maroon = 9,
    Aqua = 10,
    Lime = 11,
    Teal = 12,
    Green = 13,
    Blue = 14,
    Navy = 15,
    Black = 16
}
public static class Enumeration
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