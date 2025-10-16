using StoatSharp.Rest;

namespace StoatSharp.Requests;
internal class AdminStrikeCreateRequest : IStoatRequest
{
    public string? user_id;
    public string? reason;
}
