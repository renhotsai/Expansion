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
}
