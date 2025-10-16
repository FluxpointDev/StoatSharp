namespace StoatSharp.Rest.Requests;


internal class BulkDeleteMessagesRequest : IStoatRequest
{
    public string[]? ids { get; set; }
}