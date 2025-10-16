namespace StoatSharp.Rest.Requests;


internal class CreateEmojiRequest : IStoatRequest
{
    public string? name { get; set; }
    public CreateEmojiParent? parent { get; set; }
    public bool nsfw { get; set; }
}
internal class CreateEmojiParent
{
    public string type { get; set; } = "Server";
    public string? id { get; set; }
}
