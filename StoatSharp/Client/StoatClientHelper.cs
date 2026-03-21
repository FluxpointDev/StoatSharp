namespace StoatSharp;


/// <summary>
/// Stoat client methods.
/// </summary>
public static class StoatClientHelper
{
    /// <summary>
    /// Get a server <see cref="Role" /> from the websocket cache.
    /// </summary>
    /// <returns>
    /// <see cref="Role" /> or <see langword="null" />
    /// </returns>
    public static Role? GetRole(this StoatClient client, string roleId)
    {
        if (client.WebSocket != null && !string.IsNullOrEmpty(roleId))
        {
            foreach (Server s in client.WebSocket.ServerCache.Values)
            {
                Role role = s.GetRole(roleId);
                if (role != null)
                    return role;
            }
        }
        return null;
    }

    /// <inheritdoc cref="GetRole(StoatClient, string)" />
    public static bool TryGetRole(this StoatClient client, string roleId, out Role? role)
    {
        role = GetRole(client, roleId);
        return role != null;
    }

    /// <summary>
    /// Get a server <see cref="Emoji" /> from the websocket cache.
    /// </summary>
    /// <returns><see cref="Emoji" /> or <see langword="null" /></returns>
    public static Emoji? GetEmoji(this StoatClient client, string emojiId)
    {
        if (client.WebSocket != null && !string.IsNullOrEmpty(emojiId))
        {
            if (client.WebSocket.EmojiCache.TryGetValue(emojiId, out Emoji emoji))
                return emoji;
        }
        return null;
    }

    /// <inheritdoc cref="GetEmoji(StoatClient, string)" />
    public static bool TryGetEmoji(this StoatClient client, string emojiId, out Emoji? emoji)
    {
        emoji = GetEmoji(client, emojiId);
        return emoji != null;
    }

    /// <summary>
    /// Get a server <see cref="TextChannel" /> from the websocket cache.
    /// </summary>
    /// <returns><see cref="TextChannel" /> or <see langword="null" /></returns>
    public static TextChannel? GetTextChannel(this StoatClient client, string channelId)
    {
        if (client.WebSocket != null && !string.IsNullOrEmpty(channelId) && client.WebSocket.ChannelCache.TryGetValue(channelId, out Channel Chan) && Chan is TextChannel TC)
            return TC;
        return null;
    }

    /// <inheritdoc cref="GetTextChannel(StoatClient, string)" />
    public static bool TryGetTextChannel(this StoatClient client, string channelId, out TextChannel? channel)
    {
        channel = GetTextChannel(client, channelId);
        return channel != null;
    }

    /// <summary>
    /// Get a server <see cref="VoiceChannel" /> from the websocket cache.
    /// </summary>
    /// <returns><see cref="VoiceChannel" /> or <see langword="null" /></returns>
    public static VoiceChannel? GetVoiceChannel(this StoatClient client, string channelId)
    {
        if (client.WebSocket != null && !string.IsNullOrEmpty(channelId) && client.WebSocket.ChannelCache.TryGetValue(channelId, out Channel Chan) && Chan is VoiceChannel VC)
            return VC;
        return null;
    }

    /// <inheritdoc cref="GetVoiceChannel(StoatClient, string)" />
    public static bool TryGetVoiceChannel(this StoatClient client, string channelId, out VoiceChannel? channel)
    {
        channel = GetVoiceChannel(client, channelId);
        return channel != null;
    }

    /// <summary>
    /// Get a <see cref="Server" /> from the websocket cache.
    /// </summary>
    /// <returns><see cref="Server" /> or <see langword="null" /></returns>
    public static Server? GetServer(this StoatClient client, string serverId)
    {
        if (client.WebSocket != null && !string.IsNullOrEmpty(serverId) && client.WebSocket.ServerCache.TryGetValue(serverId, out Server Server))
            return Server;
        return null;
    }

    /// <inheritdoc cref="GetServer(StoatClient, string)" />
    public static bool TryGetServer(this StoatClient client, string serverId, out Server? server)
    {
        server = GetServer(client, serverId);
        return server != null;
    }

    /// <summary>
    /// Get a <see cref="User" /> from the websocket cache.
    /// </summary>
    /// <returns><see cref="User" /> or <see langword="null" /></returns>
    public static User? GetUser(this StoatClient client, string userId)
    {
        if (client.WebSocket != null && !string.IsNullOrEmpty(userId) && client.WebSocket.UserCache.TryGetValue(userId, out User User))
            return User;
        return null;
    }

    /// <inheritdoc cref="GetUser(StoatClient, string)" />
    public static bool TryGetUser(this StoatClient client, string userId, out User? user)
    {
        user = GetUser(client, userId);
        return user != null;
    }

    /// <summary>
    /// Get a <see cref="Channel" /> from the websocket cache.
    /// </summary>
    /// <returns><see cref="Channel" /> or <see langword="null" /></returns>
    public static Channel? GetChannel(this StoatClient client, string channelId)
    {
        if (client.WebSocket != null && !string.IsNullOrEmpty(channelId) && client.WebSocket.ChannelCache.TryGetValue(channelId, out Channel Chan))
            return Chan;
        return null;
    }

    /// <inheritdoc cref="GetChannel(StoatClient, string)" />
    public static bool TryGetChannel(this StoatClient client, string channelId, out Channel? channel)
    {
        channel = GetChannel(client, channelId);
        return channel != null;
    }

    /// <summary>
    /// Get a <see cref="GroupChannel" /> from the websocket cache.
    /// </summary>
    /// <returns><see cref="GroupChannel" /> or <see langword="null" /></returns>
    public static GroupChannel? GetGroupChannel(this StoatClient client, string channelId)
    {
        if (client.WebSocket != null && !string.IsNullOrEmpty(channelId) && client.WebSocket.ChannelCache.TryGetValue(channelId, out Channel Chan) && Chan is GroupChannel GC)
            return GC;
        return null;
    }
    /// <inheritdoc cref="GetGroupChannel(StoatClient, string)" />
    public static bool TryGetGroupChannel(this StoatClient client, string channelId, out GroupChannel? channel)
    {
        channel = GetGroupChannel(client, channelId);
        return channel != null;
    }

    /// <summary>
    /// Get a <see cref="DMChannel" /> from the websocket cache.
    /// </summary>
    /// <returns><see cref="DMChannel" /> or <see langword="null" /></returns>
    public static DMChannel? GetDMChannel(this StoatClient client, string channelId)
    {
        if (client.WebSocket != null && !string.IsNullOrEmpty(channelId) && client.WebSocket.ChannelCache.TryGetValue(channelId, out Channel Chan) && Chan is DMChannel DM)
            return DM;
        return null;
    }

    /// <inheritdoc cref="GetDMChannel(StoatClient, string)" />
    public static bool TryGetDMChannel(this StoatClient client, string channelId, out DMChannel? channel)
    {
        channel = GetDMChannel(client, channelId);
        return channel != null;
    }
}