using Newtonsoft.Json;

namespace StoatSharp;


internal class MessageWebhookJson
{

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("avatar")]
    public AttachmentJson? Avatar { get; set; }
}