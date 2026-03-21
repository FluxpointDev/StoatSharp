using System;

namespace StoatSharp;


/// <summary>
/// Custom exception for the Stoat client.
/// </summary>
public class StoatException : Exception
{
    internal StoatException(string message, int code = 0) : base(message)
    {
        Code = code;
    }

    /// <summary>
    /// The status code error for this exception if thrown by the rest client.
    /// </summary>
    public int Code { get; internal set; }
}

/// <summary>
/// Custom exception for the Stoat rest client with code.
/// </summary>
public class StoatRestException : StoatException
{
    internal StoatRestException(string message, int code, StoatErrorType type) : base(message, code)
    {
        Type = type;
    }

    /// <summary>
    /// The type of rest error triggered.
    /// </summary>
    public StoatErrorType Type { get; internal set; } = StoatErrorType.Unknown;

    /// <summary>
    /// The permission require for the error <see cref="StoatErrorType.MissingPermission"/> or <see cref="StoatErrorType.MissingUserPermission"/>
    /// </summary>
    public string? Permission { get; internal set; }
}

/// <summary>
/// Custom exception for the Stoat rest client for permission issues.
/// </summary>
public class StoatPermissionException : StoatRestException
{
    internal StoatPermissionException(string permission, int code, bool userPerm) : base(
        userPerm ? $"Request failed due to other user missing permission {permission}" : $"Request failed due to missing permission {permission}",
        code, userPerm ? StoatErrorType.MissingUserPermission : StoatErrorType.MissingPermission)
    {
        base.Permission = permission;
    }

    /// <inheritdoc cref="StoatRestException.Permission"/>
    public new string Permission => base.Permission!;
}

/// <summary>
/// Custom exception for the Stoat client when user enters a missing or wrong argument.
/// </summary>
public class StoatArgumentException : StoatException
{
    internal StoatArgumentException(string message) : base(message, 400)
    {

    }
}