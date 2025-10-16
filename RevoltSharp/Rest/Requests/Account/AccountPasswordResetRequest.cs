using StoatSharp.Rest;

namespace StoatSharp;

internal class AccountPasswordResetRequest : IStoatRequest
{
    public string token { get; set; }
    public string password { get; set; }
    public bool remove_sessions { get; set; }
}
