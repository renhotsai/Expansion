namespace Expansion;

public static class Expansion
{
    public static bool SameText(this string str, string compareStr)
    {
        return str.Equals(compareStr, StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool SameTexts(this string str, IEnumerable<string> compareList)
    {
        return compareList.Any(compareStr => str.Equals(compareStr, StringComparison.InvariantCultureIgnoreCase));
    }
}
