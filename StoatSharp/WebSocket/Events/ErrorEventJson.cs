using Newtonsoft.Json;

namespace StoatSharp.WebSocket.Events;


internal class ErrorEventJson
{
    [JsonProperty("error")]
    public StoatErrorType Error { get; set; }

    [JsonProperty("msg")]
    public string? Message { get; set; }
}