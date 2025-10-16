using Optionals;

namespace StoatSharp.Rest.Requests;


internal class CreateChannelRequest : IStoatRequest
{
    public string? name { get; set; }
    public Optional<string> type { get; set; }
    public Optional<string> description { get; set; }
    public Optional<string[]> users { get; set; }
    public Optional<bool> nsfw { get; set; }

}