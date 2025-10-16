using Newtonsoft.Json;

namespace StoatSharp.Rest;

internal class RestError
{
    [JsonProperty("type")]
    public StoatErrorType Type = StoatErrorType.Unknown;

    [JsonProperty("permission")]
    public string? Permission;
}