using System.Net;

namespace StoatSharp;

/// <summary>
/// Config options for the StoatSharp lib.
/// </summary>
public class ClientConfig
{
    /// <summary>
    /// Set your own custom client name to show in the user agent.
    /// </summary>
    public string? ClientName = "Default";

    /// <summary>
    /// Set a proxy for http rest calls.
    /// </summary>
    public IWebProxy? RestProxy = null;

    /// <summary>
    /// Set a proxy for the websocket itself.
    /// </summary>
    public IWebProxy? WebSocketProxy = null;

    internal string? UserAgent { get; set; }

    /// <summary>
    /// Do not change this unless you know what you're doing.
    /// </summary>
    /// <remarks>
    /// Defaults to https://stoat.chat/api/
    /// </remarks>
    public string ApiUrl = "https://stoat.chat/api/";

    /// <summary>
    /// Do not use this unless you know what you're doing.
    /// </summary>
    public ClientDebugConfig Debug = new ClientDebugConfig();

    /// <summary>
    /// Useful for owner checks and also used for RequireOwnerAttribute when using the built-in command handler.
    /// </summary>
    public string[] Owners = null;

    public bool OwnerBypassPermissions { get; set; }

    /// <summary>
    /// The cf_clearance cookie for Cloudflare.
    /// </summary>
    /// <remarks>
    /// This is only neccesary if Stoat is currently in Under Attack Mode (eg during a DDoS attack).
    /// Please ensure that the user agent and IP used to generate the clearance cookie will be identical to the ones used by your StoatSharp client, or else CloudFlare will not accept the clearance.
    /// </remarks>
    public string? CfClearance = null;

    /// <summary>
    /// Set the default logging mode on what to show in the console.
    /// </summary>
    public StoatLogSeverity LogMode = StoatLogSeverity.Error;
}

/// <summary>
/// Debug settings for the StoatSharp lib.
/// </summary>
public class ClientDebugConfig
{
    /// <summary>
    /// This is only used when running Windows OS, if true then StoatClient will not disable console quick edit mode for command prompt.
    /// </summary>
    public bool EnableConsoleQuickEdit { get; set; }

    /// <summary>
    /// This will be changed once you run Client.StartAsync()
    /// </summary>
    /// <remarks>
    /// Defaults to https://cdn.stoatusercontent.com/
    /// </remarks>
    public string UploadUrl { get; internal set; } = "https://cdn.stoatusercontent.com/";

    /// <summary>
    /// This will be changed once you run Client.StartAsync()
    /// </summary>
    /// <remarks>
    /// Defaults to wss://events.stoat.chat
    /// </remarks>
    public string WebsocketUrl { get; internal set; } = "wss://events.stoat.chat";

    /// <summary>
    /// Log all websocket events that you get from Stoat.
    /// </summary>
    /// <remarks>
    /// Do not use this in production!
    /// </remarks>
    public bool LogWebSocketFull { get; set; }

    /// <summary>
    /// Log the websocket ready event json data.
    /// </summary>
    public bool LogWebSocketReady { get; set; }

    /// <summary>
    /// Log when the websocket gets an error.
    /// </summary>
    public bool LogWebSocketError { get; set; }

    /// <summary>
    /// Log when the websocket gets an unknown event not used in the lib.
    /// </summary>
    public bool LogWebSocketUnknownEvent { get; set; }

    /// <summary>
    /// Log the internal request used on <see cref="StoatRestClient.SendRequestAsync(RequestType, string, IStoatRequest)"/> and <see cref="StoatRestClient.UploadFileAsync(byte[], string, UploadFileType)"/>
    /// </summary>
    public bool LogRestRequest { get; set; }

    /// <summary>
    /// Log the json content used when sending a http request.
    /// </summary>
    public bool LogRestRequestJson { get; set; }

    /// <summary>
    /// Log the http response content/json when successful.
    /// </summary>
    public bool LogRestResponseJson { get; set; }
}