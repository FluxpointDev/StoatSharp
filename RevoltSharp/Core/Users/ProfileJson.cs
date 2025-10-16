using Newtonsoft.Json;
using Optionals;

namespace StoatSharp;


internal class ProfileJson
{
    [JsonProperty("content")]
    public Optional<string?> Content { get; set; }

    [JsonProperty("background")]
    public Optional<AttachmentJson?> Background { get; set; }
}