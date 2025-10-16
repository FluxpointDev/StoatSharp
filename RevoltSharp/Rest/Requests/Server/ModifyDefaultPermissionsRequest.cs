namespace StoatSharp.Rest.Requests;

internal class ModifyDefaultPermissionsRequest : IStoatRequest
{
    public ulong permissions { get; set; }
}
