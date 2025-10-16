namespace StoatSharp.Rest.Requests;

internal class AccountLoginRequest : IStoatRequest
{
    public string email { get; set; }
    public string password { get; set; }
    public string friendly_name { get; set; }
}
