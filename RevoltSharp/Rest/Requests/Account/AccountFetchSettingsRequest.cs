using StoatSharp.Rest;

namespace StoatSharp;
internal class AccountFetchSettingsRequest : IStoatRequest
{
    public string[] keys { get; set; }
}
