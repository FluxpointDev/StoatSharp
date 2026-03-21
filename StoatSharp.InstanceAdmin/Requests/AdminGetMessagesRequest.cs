using Optionals;
using StoatSharp.Rest;

namespace StoatSharp.Requests;
internal class AdminGetMessagesRequest : IStoatRequest
{
    public Optional<string> nearby { get; set; }

    public Optional<string> before { get; set; }

    public Optional<string> after { get; set; }

    public Optional<string> sort { get; set; }

    public int limit { get; set; }

    public Optional<string> channel { get; set; }

    public Optional<string> author { get; set; }

    public Optional<string> query { get; set; }
}
