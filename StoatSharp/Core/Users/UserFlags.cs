using System;

namespace StoatSharp;


/// <summary>
/// System flags set for the user.
/// </summary>
public class UserFlags
{
    internal UserFlags(ulong value)
    {
        Raw = value;
        Types = (UserFlagType)Raw;
    }

    /// <summary>
    /// Not recommended to use, use <see cref="Has(UserFlagType)"/> instead.
    /// </summary>
    public ulong Raw { get; internal set; }

    /// <summary>
    /// Check if the user has a flag.
    /// </summary>
    /// <param name="type">The type of system flag to check</param>
    /// <returns><see langword="true" /> if user has the flag otherwise <see langword="false" /></returns>
    public bool Has(UserFlagType type) => Types.HasFlag(type);

    internal UserFlagType Types;
}

/// <summary>
/// System flags for the Stoat instance.
/// </summary>
[Flags]
public enum UserFlagType
{
    /// <summary>
    /// User has been suspended from using the Stoat instance.
    /// </summary>
    Suspended = 1,

    /// <summary>
    /// User has deleted their account on the Stoat instance.
    /// </summary>
    Deleted = 2,

    /// <summary>
    /// User has been banned from the Stoat instance.
    /// </summary>
    Banned = 4,

    /// <summary>
    /// User has been banned for spam from the Stoat instance.
    /// </summary>
    Spam = 8
}