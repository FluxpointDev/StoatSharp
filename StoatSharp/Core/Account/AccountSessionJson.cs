using Newtonsoft.Json;

namespace StoatSharp;
public class AccountSessionJson
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}
