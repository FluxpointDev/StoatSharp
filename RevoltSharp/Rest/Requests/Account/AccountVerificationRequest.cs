using StoatSharp.Rest;

namespace StoatSharp;

internal class AccountVerificationRequest : IStoatRequest
{
    public string email { get; set; }
    public string captcha { get; set; }
}
