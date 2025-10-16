using StoatSharp.Rest;

namespace StoatSharp;
internal class AccountOnboardingRequest : IStoatRequest
{
    public string username { get; set; }
}
