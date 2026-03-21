using StoatSharp.Rest;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace StoatSharp;


/// <summary>
/// Stoat http/rest methods for current user/bot account.
/// </summary>
public static class SelfUserHelper
{
    /// <inheritdoc cref="ModifySelfAsync(StoatRestClient, Option{string}, Option{string}, Option{UserStatusType}, Option{string}, Option{string})" />
    public static Task<SelfUser> ModifySelfAsync(this SelfUser user, Option<string> avatar = null, Option<string> statusText = null, Option<UserStatusType> statusType = null, Option<string> profileBio = null, Option<string> profileBackground = null)
       => ModifySelfAsync(user.Client.Rest, avatar, statusText, statusType, profileBio, profileBackground);

    /// <summary>
    /// Modify the current user/bot account avatar, status and profile.
    /// </summary>
    /// <returns>
    /// Modified <see cref="SelfUser"/>
    /// </returns>
    /// <exception cref="StoatRestException"></exception>
    public static async Task<SelfUser> ModifySelfAsync(this StoatRestClient rest, Option<string> avatar = null, Option<string> statusText = null, Option<UserStatusType> statusType = null, Option<string> profileBio = null, Option<string> profileBackground = null)
    {
        if (avatar != null)
            Conditions.AvatarIdLength(avatar.Value, nameof(ModifySelfAsync));

        if (statusText != null)
            Conditions.UserStatusTextLength(statusText.Value, nameof(ModifySelfAsync));

        if (profileBio != null)
            Conditions.UserProfileBioLength(profileBio.Value, nameof(ModifySelfAsync));

        if (profileBackground != null)
            Conditions.BackgroundIdLength(profileBackground.Value, nameof(ModifySelfAsync));

        UserJson Json = await rest.SendRequestAsync<UserJson>(RequestType.Patch, $"users/@me", ModifySelfRequest.Create(avatar, statusText, statusType, profileBio, profileBackground));
        return new SelfUser(rest.Client, Json);
    }

    /// <inheritdoc cref="GetPrivateChannelsAsync(StoatRestClient)"/>
    public static Task<IReadOnlyCollection<Channel>?> GetPrivateChannelsAsync(SelfUser user)
        => GetPrivateChannelsAsync(user.Client.Rest);

    /// <summary>
    /// Get all private DM and Group channels the current user/bot account is in.
    /// </summary>
    /// <returns>
    /// List of <see cref="Channel"/> that can be cast to <see cref="DMChannel"/> or <see cref="GroupChannel"/>
    /// </returns>
    /// <exception cref="StoatRestException"></exception>
    public static async Task<IReadOnlyCollection<Channel>?> GetPrivateChannelsAsync(this StoatRestClient rest)
    {
        HashSet<ChannelJson>? Channels = await rest.GetAsync<HashSet<ChannelJson>>("users/dms");
        if (Channels == null)
            return Array.Empty<Channel>();

        return Channels.Select(x => Channel.Create(rest.Client, x)).ToImmutableArray();
    }
}