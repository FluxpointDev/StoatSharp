using StoatSharp.Rest;
using System.Linq;

namespace StoatSharp;

public static class Conditions
{
    internal static bool OptionHasValue(Option<string> option)
    {
        if (option != null && !string.IsNullOrEmpty(option.Value))
            return true;
        return false;
    }

    #region Channel
    public static void ChannelIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"Channel id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Channel id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    public static void ChannelNameLength(string name, string request)
    {
        if (string.IsNullOrEmpty(name) || name.Length < 1)
            throw new StoatArgumentException($"Channel name can't be empty for the {request} request.");

        if (name.Length > Const.All_MaxNameLength)
            throw new StoatArgumentException($"Channel name length can't be more than {Const.All_MaxNameLength} characters for the {request} request.");
    }

    public static void ChannelDescriptionLength(string desc, string request)
    {
        if (!string.IsNullOrEmpty(desc) && desc.Length > Const.All_MaxDescriptionLength)
            throw new StoatArgumentException($"Channel description length can't be more than {Const.All_MaxDescriptionLength} characters for the {request} request.");
    }

    public static void OwnerIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"Owner id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Owner id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }
    #endregion

    #region Member
    public static void MemberIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"Member id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Member id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }
    #endregion

    #region Role
    public static void RoleIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"Role id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Role id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    public static void RoleNameLength(string name, string request)
    {
        if (string.IsNullOrEmpty(name) || name.Length < 1)
            throw new StoatArgumentException($"Role name can't be empty for the {request} request.");

        if (name.Length > Const.All_MaxNameLength)
            throw new StoatArgumentException($"Role name length can't be more than {Const.All_MaxNameLength} characters for the {request} request.");
    }

    public static void RoleListEmpty(string[] roles, string request)
    {
        if (roles == null || !roles.Any())
            throw new StoatArgumentException($"Role id list can't be empty for the {request} request.");
    }
    #endregion

    #region User
    public static void UserIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"User id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"User id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }
    #endregion

    #region Icon
    public static void IconIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"Icon id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Icon id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }
    #endregion

    #region Message

    public static void MessageIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"Message id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Message id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    public static void AttachmentIdLength(string id, string request, bool skipLength = false)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"Attachment id/file can't be empty for the {request} request.");

        if (!skipLength && id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Attachment id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    public static void MasqueradeNameLength(string url, string request)
    {
        if (!string.IsNullOrEmpty(url) && url.Length > Const.All_MaxUrlLength)
            throw new StoatArgumentException($"Masquerade name can't be more than {Const.All_MaxNameLength} characters for the {request} request.");
    }

    public static void MasqueradeAvatarUrlLength(string url, string request)
    {
        if (!string.IsNullOrEmpty(url) && url.Length > Const.All_MaxUrlLength)
            throw new StoatArgumentException($"Masquerade avatar url can't be more than {Const.All_MaxUrlLength} characters for the {request} request.");
    }

    public static void MessageIdsCount(string[] ids, string request)
    {
        if (ids != null && ids.Length > Const.Message_MaxDeleteListCount)
            throw new StoatArgumentException($"Message ids list can't be more than {Const.Message_MaxDeleteListCount} for the {request} request.");
    }

    public static void EmbedUrlLength(string url, string request)
    {
        if (!string.IsNullOrEmpty(url) && url.Length > Const.All_MaxUrlLength)
            throw new StoatArgumentException($"Embed url can't be more than {Const.All_MaxUrlLength} characters for the {request} request.");
    }

    public static void EmbedImageUrlLength(string imageUrl, string request)
    {
        if (!string.IsNullOrEmpty(imageUrl) && imageUrl.Length > Const.All_MaxUrlLength)
            throw new StoatArgumentException($"Embed image url can't be more than {Const.All_MaxUrlLength} characters for the {request} request.");
    }

    public static void EmbedTitleLength(string title, string request)
    {
        if (!string.IsNullOrEmpty(title) && title.Length > Const.Message_EmbedTitleMaxLength)
            throw new StoatArgumentException($"Embed title can't be more than {Const.Message_EmbedTitleMaxLength} characters for the {request} request.");
    }

    public static void EmbedDescriptionLength(string description, string request)
    {
        if (!string.IsNullOrEmpty(description) && description.Length > Const.All_MaxDescriptionLength)
            throw new StoatArgumentException($"Embed description can't be more than {Const.All_MaxDescriptionLength} characters for the {request} request.");
    }

    public static void EmbedIconUrl(string url, string request)
    {
        if (!string.IsNullOrEmpty(url) && url.Length > Const.All_MaxUrlLength)
            throw new StoatArgumentException($"Embed icon url can't be more than {Const.All_MaxUrlLength} characters for the {request} request.");
    }

    public static void MessagePropertiesEmpty(string content, string[] attachments, Embed[] embeds, string request)
    {
        if (string.IsNullOrEmpty(content) && (attachments == null || attachments.Length == 0) && (embeds == null || embeds.Length == 0))
            throw new StoatArgumentException($"Message content, attachments and embed can't be empty for the {request} request.");
    }

    public static void FileBytesEmpty(byte[] bytes, string request)
    {
        if (bytes == null || bytes.Length == 0)
            throw new StoatArgumentException($"File data can't be empty for the {request} request.");
    }

    public static void FileNameEmpty(string name, string request)
    {
        if (string.IsNullOrEmpty(name))
            throw new StoatArgumentException($"File name can't be empty for the {request} request.");
    }

    public static void MessageContentLength(string content, string request)
    {
        if (!string.IsNullOrEmpty(content) && content.Length > Const.Message_MaxContentLength)
            throw new StoatArgumentException($"Message content is more than {Const.Message_MaxContentLength} characters for the {request} request.");
    }

    public static void MessageSearchCount(int count, string request)
    {
        if (count < 1)
            throw new StoatArgumentException($"Message search count can't be less than 1 for the {request} request.");

        if (count > Const.Message_MaxSearchListCount)
            throw new StoatArgumentException($"Message search count can't be more than {Const.Message_MaxSearchListCount} for the {request} request.");
    }

    public static void MessageNearbyIdLength(string id, string request)
    {
        if (!string.IsNullOrEmpty(id) && id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Message nearby id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    public static void MessageAfterIdLength(string id, string request)
    {
        if (!string.IsNullOrEmpty(id) && id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Message after id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    public static void MessageBeforeIdLength(string id, string request)
    {
        if (!string.IsNullOrEmpty(id) && id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Message before id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    public static void GetImageSizeLength(int? size, string request)
    {
        if (size != null && size <= 0)
            throw new StoatArgumentException($"Image size cannot be zero or less than for the {request} GetUrl function.");
    }

    public static void ReplyListCount(MessageReply[] list, string request)
    {
        if (list != null && list.Length > 5)
            throw new StoatArgumentException($"Replies list can't be more than 5 for the {request} request.");
    }

    #endregion

    #region Server
    public static void ServerIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"Server id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Server id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }
    public static void ServerNameLength(string name, string request)
    {
        if (string.IsNullOrEmpty(name) || name.Length < 1)
            throw new StoatArgumentException($"Server name can't be empty for the {request} request.");

        if (name.Length > Const.All_MaxNameLength)
            throw new StoatArgumentException($"Server name length can't be more than {Const.All_MaxNameLength} characters for the {request} request.");
    }
    public static void ServerDescriptionLength(string name, string request)
    {
        if (name.Length > Const.All_MaxDescriptionLength)
            throw new StoatArgumentException($"Server description length can't be more than {Const.All_MaxNameLength} characters for the {request} request.");
    }
    public static void InviteCodeEmpty(string inviteCode, string request)
    {
        if (string.IsNullOrWhiteSpace(inviteCode))
            throw new StoatArgumentException($"Invite code can't be empty for the {request} request.");
    }
    #endregion

    #region Emoji

    public static void EmojiIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"Emoji id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Emoji id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    public static void EmojiNameLength(string name, string request)
    {
        if (string.IsNullOrEmpty(name) || name.Length < 1)
            throw new StoatArgumentException($"Emoji name can't be empty for the {request} request.");

        if (name.Length > Const.All_MaxNameLength)
            throw new StoatArgumentException($"Emoji name length can't be more than {Const.All_MaxNameLength} characters for the {request} request.");
    }

    #endregion

    #region Bot

    public static void AvatarIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"Avatar id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Avatar id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    public static void UserStatusTextLength(string text, string request)
    {
        if (!string.IsNullOrEmpty(text) && text.Length > Const.User_MaxStatusTextLength)
            throw new StoatArgumentException($"User status text length can't be more than {Const.User_MaxStatusTextLength} characters for the {request} request.");
    }

    public static void UserProfileBioLength(string text, string request)
    {
        if (!string.IsNullOrEmpty(text) && text.Length > Const.User_ProfileBioLength)
            throw new StoatArgumentException($"User bio text length can't be more than {Const.User_ProfileBioLength} characters for the {request} request.");
    }

    public static void BackgroundIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id) || id.Length < 1)
            throw new StoatArgumentException($"Background id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Background id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    public static void NotAllowedForBots(StoatRestClient rest, string request)
    {
        if (!rest.Client.IsUserAccount)
            throw new StoatRestException($"The {request} is not allowed to be used for bots.", 400, StoatErrorType.NotAllowedForBots);
    }

    public static void NotAllowedForUsers(StoatRestClient rest, string request)
    {
        if (rest.Client.IsUserAccount)
            throw new StoatRestException($"The {request} is not allowed to be used for user accounts.", 400, StoatErrorType.NotAllowedForBots);
    }

    public static void NotSelf(StoatRestClient rest, string userId, string request)
    {
        if (!string.IsNullOrEmpty(userId) && userId == rest.Client.CurrentUser.Id)
            throw new StoatArgumentException($"Cannot perform the {request} request against the current user/bot account.");
    }

    public static void WebSocketOnly(StoatRestClient rest, string request)
    {
        if (rest.Client.WebSocket == null)
            throw new StoatArgumentException($"The {request} is only allowed to be used in WebSocket mode only.");
    }

    #endregion

    #region Webhook

    public static void WebhookNameLength(string name, string request)
    {
        if (string.IsNullOrEmpty(name) || name.Length < 1)
            throw new StoatArgumentException($"Webhook name can't be empty for the {request} request.");

        if (name.Length > Const.All_MaxNameLength)
            throw new StoatArgumentException($"Webhook name length can't be more than {Const.All_MaxNameLength} characters for the {request} request.");
    }

    public static void WebhookAvatarIdLength(string name, string request)
    {
        if (string.IsNullOrEmpty(name) || name.Length < 1)
            throw new StoatArgumentException($"Webhook avatar id can't be empty for the {request} request.");

        if (name.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Webhook avatar id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    #endregion
}