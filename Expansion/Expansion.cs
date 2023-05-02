namespace Expansion;

public static class Expansion
{
    public static bool SameText(this string value, string compareStr)
    {
        return str.Equals(compareStr, StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool SameTexts(this string value, string[] compareArray)
    {
        return compareArray.ConContains(value, StringComparison.InvariantCultureIgnoreCase);
    }
}
