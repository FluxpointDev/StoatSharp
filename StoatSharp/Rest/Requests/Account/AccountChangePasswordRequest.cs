using StoatSharp.Rest;

namespace StoatSharp;

internal class AccountChangePasswordRequest : IStoatRequest
{
    public string password { get; set; }
    public string current_password { get; set; }
}
