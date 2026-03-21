using StoatSharp.Rest;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoatSharp;


/// <summary>
/// Stoat http/rest methods for current user/bot account.
/// </summary>
public static class BotHelper
{
    /// <inheritdoc cref="StoatRestClient.UploadFileAsync(byte[], string, UploadFileType)" />
    public static Task<FileAttachment> UploadFileAsync(this Channel channel, byte[] bytes, string name, UploadFileType type)
       => channel.Client.Rest.UploadFileAsync(bytes, name, type);

    /// <inheritdoc cref="StoatRestClient.UploadFileAsync(byte[], string, UploadFileType)" />
    public static Task<FileAttachment> UploadFileAsync(this Channel channel, string path, UploadFileType type)
        => channel.Client.Rest.UploadFileAsync(File.ReadAllBytes(path), path.Split('.').Last(), type);

    /// <inheritdoc cref="GetSavedMessagesChannelAsync(StoatRestClient)" />
    public static Task<SavedMessagesChannel?> GetSavedMessagesChannelAsync(this SelfUser user)
        => GetSavedMessagesChannelAsync(user.Client.Rest);

    /// <summary>
    /// Get or create the current user/bot's saved messages channel that is private.
    /// </summary>
    /// <returns>
    /// <see cref="SavedMessagesChannel" /> or <see langword="null" />
    /// </returns>
    /// <exception cref="StoatRestException"></exception>
    public static async Task<SavedMessagesChannel?> GetSavedMessagesChannelAsync(this StoatRestClient rest)
    {
        if (rest.Client.SavedMessagesChannel != null)
            return rest.Client.SavedMessagesChannel;

        ChannelJson SC = await rest.GetAsync<ChannelJson>("/users/" + rest.Client.CurrentUser.Id + "/dm");
        if (SC == null)
            return null;
        return Channel.Create(rest.Client, SC) as SavedMessagesChannel;
    }

    /// <summary>
    /// Get information about a public bot account.
    /// </summary>
    /// <returns>
    /// <see cref="PublicBot"/> or <see langword="null" />
    /// </returns>
    /// <exception cref="StoatRestException"></exception>
    public static async Task<PublicBot?> GetPublicBotAsync(this StoatRestClient rest, string id)
    {
        Conditions.UserIdLength(id, nameof(GetPublicBotAsync));

        PublicBotJson? Bot = await rest.GetAsync<PublicBotJson>($"/bots/{id}/invite");
        if (Bot == null)
            return null;

        return new PublicBot(rest.Client, Bot);
    }

    /// <summary>
    /// Get the current query info of the connected Stoat instance.
    /// </summary>
    /// <returns>
    /// <see cref="Query"/> or <see langword="null" />
    /// </returns>
    /// <exception cref="StoatRestException"></exception>
    public static async Task<Query?> GetQueryAsync(this StoatRestClient rest, bool throwRequest = false)
    {
        QueryJson? Query = await rest.GetAsync<QueryJson>("/", null, throwRequest);

        return new Query(Query);
    }
}
