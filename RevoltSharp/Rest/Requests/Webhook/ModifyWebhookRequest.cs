using Optionals;
using System.Collections.Generic;

namespace StoatSharp.Rest.Requests;

internal class ModifyWebhookRequest : IStoatRequest
{
    public Optional<string> name { get; set; }
    public Optional<string> avatar { get; set; }
    public Optional<List<string>> remove { get; set; }
    public Optional<ulong> permissions { get; set; }
}
