using System.Buffers;

namespace StoatSharp;
internal static class StringExtensions
{
    public static string Create<TState>(int length, TState state, SpanAction<char, TState> action)
    {
        return string.Create(length, state, action);
    }
}
