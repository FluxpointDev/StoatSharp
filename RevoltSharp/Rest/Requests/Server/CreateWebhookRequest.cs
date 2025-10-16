using Newtonsoft.Json;
using Optionals;

namespace StoatSharp.Rest.Requests;

internal class CreateWebhookRequest : IStoatRequest
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("avatar")]
    public Optional<string> Avatar { get; set; }
}