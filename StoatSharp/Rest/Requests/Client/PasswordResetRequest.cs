using StoatSharp.Rest;

namespace StoatSharp;

internal class PasswordResetRequest : IStoatRequest
{
    public string email { get; set; }
    public string captcha { get; set; }
}
