using System.Numerics;

namespace StoatSharp;

public static class GlobalExtensions
{
    public static int ToInt(this BigInteger bint)
    {
        if (int.TryParse(bint.ToString(), out int number))
            return number;

        if (bint > 0)
            throw new StoatArgumentException($"Failed to parse big int because it's bigger than Int.MaxValue ({int.MaxValue})");

        throw new StoatArgumentException($"Failed to parse big int becasue it's less than Int.Minvalue ({int.MinValue})");
    }
}
