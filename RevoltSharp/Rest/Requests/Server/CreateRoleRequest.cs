using Optionals;

namespace StoatSharp.Rest.Requests;


internal class CreateRoleRequest : IStoatRequest
{
    public string? name { get; set; }
    public Optional<int> rank { get; set; }
}