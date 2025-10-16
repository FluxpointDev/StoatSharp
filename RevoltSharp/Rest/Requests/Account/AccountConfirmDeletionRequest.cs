using StoatSharp.Rest;

namespace StoatSharp;

internal class AccountConfirmDeletionRequest : IStoatRequest
{
    public string token { get; set; }
}
