using Newtonsoft.Json;

namespace StoatSharp.WebSocket;


internal class ServerEmojiCreatedEventJson : EmojiJson
{

}
internal class ServerEmojiDeleteEventJson
{
    [JsonProperty("id")]
    public string? EmojiId;
}