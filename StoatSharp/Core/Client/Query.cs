namespace StoatSharp;

/// <summary>
/// Query information about the connected Stoat instance.
/// </summary>
public class Query
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    internal Query(QueryJson json)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        StoatVersion = json.RevoltVersion;
        AppUrl = json.AppUrl;
        WebsocketUrl = json.WebsocketUrl;
        CaptchaEnabled = json.ServerFeatures.captcha.enabled;
        EmailEnabled = json.ServerFeatures.email;
        InviteOnly = json.ServerFeatures.invite_only;
        ImageServerUrl = json.ServerFeatures.ImageServer.url;
        if (!ImageServerUrl.EndsWith("/"))
            ImageServerUrl += "/";

        JanuaryServerUrl = json.ServerFeatures.JanuaryServer.url;
        if (!JanuaryServerUrl.EndsWith("/"))
            JanuaryServerUrl += "/";
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public string StoatVersion { get; internal set; }

    public string AppUrl { get; internal set; }

    public string WebsocketUrl { get; internal set; }

    public bool CaptchaEnabled { get; internal set; }

    public bool EmailEnabled { get; internal set; }

    public bool InviteOnly { get; internal set; }

    public string ImageServerUrl { get; internal set; }

    public string JanuaryServerUrl { get; internal set; }

    //public string VoiceApiUrl { get; internal set; }

    //public string VoiceWebsocketUrl { get; internal set; }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
