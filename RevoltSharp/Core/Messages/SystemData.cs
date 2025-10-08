namespace RevoltSharp;

/// <summary>
/// Raw system data for the system message.
/// </summary>
public abstract class SystemData
{
    internal string? BaseText { get; set; }
    internal string? BaseId { get; set; }
    internal string? BaseBy { get; set; }
    internal string? BaseName { get; set; }
    internal string? BaseFrom { get; set; }
    internal string? BaseTo { get; set; }
}

/// <summary>
/// Unknown system messages
/// </summary>
public class SystemDataUnknown : SystemData
{
    public string Name => BaseName;
    public string From => BaseFrom;
    public string To => BaseTo;
    public string Text => BaseText;
    public string Id => BaseId;
    public string By => BaseBy;
}

public class SystemDataMessagePinned : SystemData
{
    public string Id => BaseId;
    public string By => BaseBy;
}

/// <summary>
/// System message with text content
/// </summary>
public class SystemDataText : SystemData
{
    public string Text => BaseText;
}

/// <summary>
/// User has been added to a group channel
/// </summary>
public class SystemDataUserAdded : SystemData
{
    public string Id => BaseId;
    public string By => BaseBy;
}

/// <summary>
/// User has been removed from the group channel
/// </summary>
public class SystemDataUserRemoved : SystemData
{
    public string Id => BaseId;
    public string By => BaseBy;
}

/// <summary>
/// Member has joined the server
/// </summary>
public class SystemDataUserJoined : SystemData
{
    public string Id => BaseId;
}

/// <summary>
/// Member has left the server
/// </summary>
public class SystemDataUserLeft : SystemData
{
    public string Id => BaseId;
}

/// <summary>
/// Member has been kicked from the server
/// </summary>
public class SystemDataUserKicked : SystemData
{
    public string Id => BaseId;
}

/// <summary>
/// Member has been banned from the server
/// </summary>
public class SystemDataUserBanned : SystemData
{
    public string Id => BaseId;
}

/// <summary>
/// Group channel name has been changed
/// </summary>
public class SystemDataChannelRenamed : SystemData
{
    public string Name => BaseName;
    public string By => BaseBy;
}

/// <summary>
/// Group channel description has been changed
/// </summary>
public class SystemDataChannelDescriptionChanged : SystemData
{
    public string By => BaseBy;
}

/// <summary>
/// Group channel icon has been changed
/// </summary>
public class SystemDataChannelIconChanged : SystemData
{
    public string By => BaseBy;
}

/// <summary>
/// Group channel ownership has been changed
/// </summary>
public class SystemDataChannelOwnershipChanged : SystemData
{
    public string From => BaseFrom;
    public string To => BaseTo;
}
