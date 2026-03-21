using Newtonsoft.Json;

namespace StoatSharp;

internal class SafetyUserStrikeJson
{
    [JsonProperty("_id")]
    public string? Id;

    [JsonProperty("user_id")]
    public string? UserId;

    [JsonProperty("reason")]
    public string? Reason;
}
