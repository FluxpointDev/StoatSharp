using Newtonsoft.Json;
using Optionals;

namespace StoatSharp.WebSocket;


internal class ServerMemberJoinEventJson
{
    [JsonProperty("id")]
    public string? ServerId;

    [JsonProperty("user")]
    public string? UserId;

    //[JsonProperty("member")]
    //public ServerMemberJson Member;
}
internal class ServerMemberLeaveEventJson
{
    [JsonProperty("id")]
    public string? ServerId;

    [JsonProperty("user")]
    public string? UserId;
}
internal class ServerMemberUpdateEventJson
{
    [JsonProperty("id")]
    public ServerMemberIdsJson? Id;

    [JsonProperty("data")]
    public PartialServerMemberJson? Data;

    [JsonProperty("clear")]
    public Optional<string[]> Clear;
}