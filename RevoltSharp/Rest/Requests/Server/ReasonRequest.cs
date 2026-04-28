using Optionals;

namespace StoatSharp.Rest.Requests;


internal class ReasonRequest : IStoatRequest
{
    public Optional<string> reason { get; set; }

    public Optional<int> delete_message_seconds { get; set; }

}