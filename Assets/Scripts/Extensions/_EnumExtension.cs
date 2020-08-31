using System;
using System.Collections.Generic;
using System.Globalization;

public static class EnumExtension
{
    /// <summary>
    /// Please use this function for EnumFlags.
    /// If u want to use diffrent type.
    /// I dont know what happen after that
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    public static List<T> SplitFlagEnumToList<T>(this T values) where T : struct
    {
        List<T> result = new List<T>();

        T[] Arr = (T[])Enum.GetValues(typeof(T));

        for (int i = 0; i < Arr.Length; i++)
        {
            if (values.IsSet<T>(Arr[i]))
            {
                result.Add(Arr[i]);
            }
        }
        return result.Count > 0 ? result : null;
    }

    /// <summary>
    /// This function just only word with Enum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="src"></param>
    /// <returns></returns>
    public static T Parse<T>(string[] values) where T : struct
    {
        return (T)Enum.Parse(typeof(T), string.Join(",", values));
    }

    public static T Parse<T>(string values) where T : struct
    {
        return (T)Enum.Parse(typeof(T), values);
    }

    public static T Parse<T>(string values, char key) where T : struct
    {
        string[] split = values.Split(key);

        if (string.IsNullOrEmpty(values))
            throw new ArgumentException(String.Format("Argumnent {0} is null or empty", values));

        foreach (var str in split)
            str.Trim();

        return (T)Enum.Parse(typeof(T), string.Join(",", split));
    }


    public static T Next<T>(this T src) where T : struct
    {
        if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf<T>(Arr, src) + 1;
        return (Arr.Length == j) ? Arr[0] : Arr[j];
    }

    public static int LengthEnum<T>(this T src) where T : struct
    {
        if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf<T>(Arr, src) + 1;

        return Arr.Length;
    }

    public static bool IsSet<T>(this T input, T matchTo) where T : struct //the constraint I want that doesn't exist in C#3
    {
        return (Convert.ToUInt32(input) & Convert.ToUInt32(matchTo)) != 0;
    }

    public static bool IsSet(this Enum input, Enum matchTo)
    {
        return (Convert.ToUInt32(input) & Convert.ToUInt32(matchTo)) != 0;
    }

    private static ulong ToUInt64(object value)
    {
        switch (Convert.GetTypeCode(value))
        {
            case TypeCode.SByte:
            case TypeCode.Int16:
            case TypeCode.Int32:
            case TypeCode.Int64:
                return (ulong)Convert.ToInt64(value, CultureInfo.InvariantCulture);

            case TypeCode.Byte:
            case TypeCode.UInt16:
            case TypeCode.UInt32:
            case TypeCode.UInt64:
                return Convert.ToUInt64(value, CultureInfo.InvariantCulture);
        }

        throw new InvalidOperationException("Unknown enum type.");
    }
}