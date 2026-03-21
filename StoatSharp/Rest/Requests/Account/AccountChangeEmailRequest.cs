using StoatSharp.Rest;

namespace StoatSharp;

internal class AccountChangeEmailRequest : IStoatRequest
{
    public string email { get; set; }
    public string current_password { get; set; }
}
