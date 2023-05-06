namespace Expansion;

public static class Expansion
{
    public static bool SameText(this string? value, string? compareStr)
    {
        if (value == null)
        {
            return compareStr == null;
        }
        return value.Equals(compareStr, StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool SameTexts(this string? value, params string[]? compareArray)
    {
        if (value == null)
        {
            return compareArray == null;
        }
        return compareArray!.Contains(value,StringComparer.InvariantCultureIgnoreCase);
    }
    
    public static T ConvertStringToEnum<T>(string str) where T : struct
    {
        return Enum.TryParse(str, true, out T enumValue) ? enumValue : new T();
    }
    
    public static string ConvertConstValueToName<T>(string str)
    {
        var typeName = string.Empty;
        foreach (var fieldInfo in typeof(T).GetFields())
        {
            if (fieldInfo.GetValue(obj: null)!.ToString() != str) continue;
            typeName = fieldInfo.Name;
            break;
        }
        return typeName;
    }
}
