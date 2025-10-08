using System;

namespace RevoltSharp;

/// <summary>
/// List of message flags.
/// </summary>
[Flags]
public enum MessageFlag : ulong
{
    /// <summary>
    /// Message has supressed notifications for other users.
    /// </summary>
    SupressNotifications = 1L << 0,

    /// <summary>
    /// Message has mentioned all members.
    /// </summary>
    MentionsEveryone = 1L << 1,

    /// <summary>
    /// Message has mentioned online members.
    /// </summary>
    MentionsOnline = 1L << 1
}
