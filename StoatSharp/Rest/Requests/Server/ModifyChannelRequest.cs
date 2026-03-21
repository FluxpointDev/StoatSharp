using Optionals;
using System.Collections.Generic;

namespace StoatSharp.Rest.Requests;


internal class ModifyChannelRequest : IStoatRequest
{
    public Optional<string> name { get; set; }
    public Optional<string> description { get; set; }
    public Optional<string> icon { get; set; }
    public Optional<bool> nsfw { get; set; }
    public Optional<List<string>> remove { get; set; }
    public Optional<string> owner { get; set; }



    public void RemoveValue(string value)
    {
        if (!remove.HasValue)
            remove = Optional.Some(new List<string>());

        remove.Value.Add(value);
    }
}