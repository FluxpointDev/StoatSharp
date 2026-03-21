using Newtonsoft.Json;

namespace StoatSharp.Requests;
internal class AdminMessagesDataJson
{
    [JsonProperty("messages")]
    public MessageJson[]? Messages;

    [JsonProperty("users")]
    public UserJson[]? Users;
}
