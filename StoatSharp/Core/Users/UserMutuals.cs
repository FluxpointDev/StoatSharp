using System;
using System.Collections.Generic;

namespace StoatSharp;

public class UserMutuals
{
    internal UserMutuals(UserMutualsJson? json)
    {
        if (json == null || json.users == null)
            Users = Array.Empty<string>();
        else
            Users = json.users;

        if (json == null || json.servers == null)
            Servers = Array.Empty<string>();
        else
            Servers = json.servers;

        if (json == null || json.channels == null)
            Channels = Array.Empty<string>();
        else
            Channels = json.channels;
    }

    public IReadOnlyCollection<string> Users { get; internal set; }
    public IReadOnlyCollection<string> Servers { get; internal set; }
    public IReadOnlyCollection<string> Channels { get; internal set; }
}
