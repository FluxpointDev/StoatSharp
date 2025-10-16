namespace StoatSharp.Rest.Requests;
internal class AccountLoginMFARequest : IStoatRequest
{
    public string mfa_ticket { get; set; }
    public string friendly_name { get; set; }
    public AccountLoginMFAResponseRequest mfa_response { get; set; } = new AccountLoginMFAResponseRequest();
}
internal class AccountLoginMFAResponseRequest
{
    public string recovery_code { get; set; }
    public string totp_code { get; set; }
}
