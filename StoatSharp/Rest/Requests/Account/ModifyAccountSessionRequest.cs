using StoatSharp.Rest;

namespace StoatSharp;
internal class ModifyAccountSessionRequest : IStoatRequest
{
    public string friendly_name { get; set; }
}
