using StoatSharp.Rest;

namespace StoatSharp;

internal class CreateAccountRequest : IStoatRequest
{
    public string email { get; set; }
    public string password { get; set; }
    public string? invite { get; set; }
    public string? captcha { get; set; }
}
