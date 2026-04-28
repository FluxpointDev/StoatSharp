namespace StoatSharp;


/// <summary>
/// Server invite
/// </summary>
public class Invite : Entity
{
    internal Invite(StoatClient client, InviteJson model) : base(client)
    {
        Code = model.Code;
        ChannelId = model.ChannelId;
        ChannelName = model.ChannelName;
        ChannelDescription = model.ChannelDescription;
        CreatorName = model.CreatorName;
        CreatorAvatar = Attachment.Create(client, model.CreatorAvatar);
        if (model.Type == "Server")
            IsServer = true;
        else if (model.Type == "Group")
            IsGroup = true;
        MemberCount = model.MemberCount;
        ServerId = model.ServerId;
        ServerName = model.ServerName;
        if (model.ServerIcon != null)
            ServerIcon = Attachment.Create(client, model.ServerIcon);
        if (model.ServerBanner != null)
            ServerBanner = Attachment.Create(client, model.ServerBanner);
        ServerFlags = model.ServerFlags;
    }
    public string Code { get; internal set; }
    public string ChannelId { get; internal set; }
    public Channel? Channel => Client.GetChannel(ChannelId);
    public string ChannelName { get; internal set; }
    public string? ChannelDescription { get; internal set; }
    public string CreatorName { get; internal set; }
    public Attachment? CreatorAvatar { get; internal set; }
    public bool IsServer { get; internal set; }
    public bool IsGroup { get; internal set; }
    public ulong MemberCount { get; internal set; }
    public string ServerId { get; internal set; }
    public string ServerName { get; internal set; }
    public Attachment? ServerIcon { get; internal set; }
    public Attachment? ServerBanner { get; internal set; }
    public ServerFlags ServerFlags { get; internal set; }

    /// <summary> Returns a string that represents the current object.</summary>
    /// <returns> Channel name invite </returns>
    public override string ToString()
    {
        return ChannelName + " invite";
    }
}

public class CreatedInvite : Entity
{
    internal CreatedInvite(StoatClient client, CreateInviteJson model) : base(client)
    {
        Code = model.Code;
        CreatorId = model.CreatorId;
        ChannelId = model.ChannelId;
        if (model.ChannelType == "Server")
            IsServer = true;
        else if (model.ChannelType == "Group")
            IsGroup = true;
    }

    public string Code { get; internal set; }
    public string CreatorId { get; internal set; }

    public User? Creator => Client.GetUser(CreatorId);
    public string ChannelId { get; internal set; }
    public Channel? Channel => Client.GetChannel(ChannelId);
    public bool IsServer { get; internal set; }
    public bool IsGroup { get; internal set; }
}