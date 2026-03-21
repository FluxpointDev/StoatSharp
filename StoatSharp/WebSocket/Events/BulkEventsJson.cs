using Newtonsoft.Json;

namespace StoatSharp.WebSocket.Events;

internal class BulkEventsJson
{
    [JsonProperty("v")]
    public dynamic[]? Events;
}