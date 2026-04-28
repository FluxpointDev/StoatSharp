using System;

namespace StoatSharp;

[Flags]
public enum ServerFlags : ulong
{
    Official = 1UL << 0,
    Verified = 1UL << 1,
}
