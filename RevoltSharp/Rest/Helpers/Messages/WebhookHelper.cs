using Optionals;
using StoatSharp.Rest;
using StoatSharp.Rest.Requests;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace StoatSharp;

/// <summary>
/// Stoat http/rest methods for webhooks.
/// </summary>
public static class WebhookHelper
{
    /// <summary>
    /// The user that created this webhook.
    /// </summary>
    /// <remarks>
    /// Will be <see langword="null" /> if using <see cref="ClientMode.Http"/> or you can't access the user.
    /// </remarks>
    /// <returns><see cref="User"/></returns>
    public static Task<User?> GetCreatorAsync(this Webhook wh)
        => UserHelper.GetUserAsync(wh.Client.Rest, wh.CreatedUserId);

    /// <inheritdoc cref="GetWebhooksAsync(StoatRestClient, string)" />
    public static Task<IReadOnlyCollection<Webhook>?> GetWebhooksAsync(this GroupChannel channel)
        => GetWebhooksAsync(channel.Client.Rest, channel.Id);

    /// <inheritdoc cref="GetWebhooksAsync(StoatRestClient, string)" />
    public static Task<IReadOnlyCollection<Webhook>?> GetWebhooksAsync(this TextChannel channel)
        => GetWebhooksAsync(channel.Client.Rest, channel.Id);

    /// <summary>
    /// Get all webhooks for this channel.
    /// </summary>
    /// <returns>List of <see cref="Webhook"/></returns>
    public static async Task<IReadOnlyCollection<Webhook>?> GetWebhooksAsync(this StoatRestClient rest, string channelId)
    {
        Conditions.ChannelIdLength(channelId, nameof(GetWebhooksAsync));

        WebhookJson[]? Webhooks = await rest.GetAsync<WebhookJson[]>($"/channels/{channelId}/webhooks");
        if (Webhooks == null)
            return Array.Empty<Webhook>();

        return Webhooks.Select(x => new Webhook(rest.Client, x)).ToImmutableArray();
    }

    /// <inheritdoc cref="CreateWebhookAsync(StoatRestClient, string, string, string)" />
    public static Task<Webhook> CreateWebhookAsync(this GroupChannel channel, string webhookName, string? webhookAvatarId = null)
        => CreateWebhookAsync(channel.Client.Rest, channel.Id, webhookName, webhookAvatarId);

    /// <inheritdoc cref="CreateWebhookAsync(StoatRestClient, string, string, string)" />
    public static Task<Webhook> CreateWebhookAsync(this TextChannel channel, string webhookName, string? webhookAvatarId = null)
        => CreateWebhookAsync(channel.Client.Rest, channel.Id, webhookName, webhookAvatarId);


    /// <summary>
    /// Create a webhook for the channel.
    /// </summary>
    /// <returns><see cref="Webhook"/></returns>
    /// <exception cref="StoatArgumentException" />
    /// <exception cref="StoatRestException" />
    /// <exception cref="StoatPermissionException" />
    public static async Task<Webhook> CreateWebhookAsync(this StoatRestClient rest, string channelId, string name, string? avatarId = null)
    {
        Conditions.ChannelIdLength(channelId, nameof(CreateWebhookAsync));
        Conditions.WebhookNameLength(name, nameof(CreateWebhookAsync));

        CreateWebhookRequest Req = new CreateWebhookRequest
        {
            Name = name
        };
        if (!string.IsNullOrEmpty(avatarId))
        {
            Conditions.WebhookAvatarIdLength(avatarId, nameof(CreateWebhookAsync));
            Req.Avatar = Optional.Some(avatarId);
        }

        WebhookJson Data = await rest.PostAsync<WebhookJson>($"channels/{channelId}/webhooks", Req);
        return new Webhook(rest.Client, Data);
    }

    /// <summary>
    /// Get the current webhook for this webhook client.
    /// </summary>
    /// <param name="wh"></param>
    /// <returns><see cref="Webhook"/></returns>
    public static Task<Webhook?> GetWebhookAsync(this StoatWebhookClient wh)
        => GetWebhookAsync(wh.Client.Rest, wh.Id, wh.Token);

    /// <summary>
    /// Get a webhook using the id and token.
    /// </summary>
    /// <param name="rest"></param>
    /// <param name="webhookId"></param>
    /// <param name="webhookToken"></param>
    /// <returns><see cref="Webhook"/></returns>
    public static async Task<Webhook?> GetWebhookAsync(this StoatRestClient rest, string webhookId, string webhookToken)
    {
        WebhookJson? Data = await rest.GetAsync<WebhookJson>($"webhooks/{webhookId}/{webhookToken}");
        if (Data == null)
            return null;
        return new Webhook(rest.Client, Data);
    }

    /// <summary>
    /// Delete the current webhook for this webhook client.
    /// </summary>
    /// <param name="wh"></param>
    /// <returns></returns>
    public static Task DeleteWebhookAsync(this StoatWebhookClient wh)
        => InternalDeleteWebhookAsync(wh.Client.Rest, wh.Id, wh.Token);

    /// <summary>
    /// Delete a webhook that you can manage
    /// </summary>
    /// <param name="rest"></param>
    /// <param name="webhookId"></param>
    /// <returns></returns>
    public static Task DeleteWebhookAsync(this StoatRestClient rest, string webhookId)
        => InternalDeleteWebhookAsync(rest, webhookId, null);

    /// <summary>
    /// Delete a webhook
    /// </summary>
    /// <param name="rest"></param>
    /// <param name="webhookId"></param>
    /// <param name="webhookToken"></param>
    /// <returns></returns>
    public static Task DeleteWebhookAsync(this StoatRestClient rest, string webhookId, string webhookToken)
        => InternalDeleteWebhookAsync(rest, webhookId, webhookToken);

    /// <summary>
    /// Delete the current webhook.
    /// </summary>
    /// <param name="wh"></param>
    /// <returns></returns>
    public static Task DeleteAsync(this Webhook wh)
        => InternalDeleteWebhookAsync(wh.Client.Rest, wh.Id, wh.Token);

    /// <summary>
    /// Delete a webhook.
    /// </summary>
    /// <param name="rest"></param>
    /// <param name="webhookId"></param>
    /// <param name="webhookToken"></param>
    /// <returns></returns>
    internal static async Task InternalDeleteWebhookAsync(this StoatRestClient rest, string webhookId, string webhookToken)
    {
        await rest.DeleteAsync($"webhooks/{webhookId}" + (!string.IsNullOrEmpty(webhookToken) ? "/" + webhookToken : null));
    }

    /// <inheritdoc cref="InternalModifyWebhookAsync(StoatRestClient, string, string, Option{string}, Option{string}, Option{WebhookPermissions})"/>
    public static Task ModifyAsync(this Webhook wh, Option<string> name = null, Option<string> avatarId = null, Option<WebhookPermissions> permissions = null)
        => ModifyWebhookAsync(wh.Client.Rest, wh.Id, wh.Token, name, avatarId, permissions);

    /// <inheritdoc cref="InternalModifyWebhookAsync(StoatRestClient, string, string, Option{string}, Option{string}, Option{WebhookPermissions})"/>
    public static Task ModifyWebhookAsync(this StoatWebhookClient wh, Option<string> name = null, Option<string> avatarId = null, Option<WebhookPermissions> permissions = null)
        => ModifyWebhookAsync(wh.Client.Rest, wh.Id, wh.Token, name, avatarId, permissions);

    /// <inheritdoc cref="InternalModifyWebhookAsync(StoatRestClient, string, string, Option{string}, Option{string}, Option{WebhookPermissions})"/>
    public static Task<Webhook> ModifyWebhookAsync(this StoatRestClient rest, string webhookId, string webhookToken, Option<string> name = null, Option<string> avatarId = null, Option<WebhookPermissions> permissions = null)
        => InternalModifyWebhookAsync(rest, webhookId, webhookToken, name, avatarId, permissions);

    /// <inheritdoc cref="InternalModifyWebhookAsync(StoatRestClient, string, string, Option{string}, Option{string}, Option{WebhookPermissions})"/>
    public static Task<Webhook> ModifyWebhookAsync(this StoatRestClient rest, string webhookId, Option<string> name = null, Option<string> avatarId = null, Option<WebhookPermissions> permissions = null)
        => InternalModifyWebhookAsync(rest, webhookId, null, name, avatarId, permissions);

    /// <summary>
    /// Edit a webhook that you can manage.
    /// </summary>
    /// <param name="rest"></param>
    /// <param name="webhookId"></param>
    /// <param name="webhookToken"></param>
    /// <param name="name"></param>
    /// <param name="avatarId"></param>
    /// <param name="permissions"></param>
    /// <returns><see cref="Webhook"/></returns>
    internal static async Task<Webhook> InternalModifyWebhookAsync(this StoatRestClient rest, string webhookId, string? webhookToken, Option<string> name = null, Option<string> avatarId = null, Option<WebhookPermissions> permissions = null)
    {
        ModifyWebhookRequest req = new ModifyWebhookRequest();
        if (name != null)
            Conditions.WebhookNameLength(name.Value, nameof(ModifyWebhookAsync));

        if (avatarId != null)
        {
            if (string.IsNullOrEmpty(avatarId.Value))
            {
                req.remove = Optional.Some(new List<string>());
                req.remove.Value.Add("Avatar");
            }
            else
            {
                Conditions.AttachmentIdLength(avatarId.Value, nameof(ModifyWebhookAsync));
                req.avatar = Optional.Some(avatarId.Value);
            }
        }

        if (permissions != null)
        {
            if (permissions.Value == null)
                throw new StoatArgumentException("Webhook permissions is not given for Modify Webhook.");

            req.permissions = Optional.Some(permissions.Value.Raw);
        }

        WebhookJson? Data = await rest.PatchAsync<WebhookJson>($"webhooks/{webhookId}" + (!string.IsNullOrEmpty(webhookToken) ? "/" + webhookToken : null), req);
        return new Webhook(rest.Client, Data);
    }
}