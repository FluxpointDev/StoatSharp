using Optionals;
using System;
using System.Collections.Generic;

namespace StoatSharp.Rest.Requests;


internal class EditMemberRequest : IStoatRequest
{
    public Optional<string[]> roles { get; set; }
    public Optional<string> nickname { get; set; }
    public Optional<AttachmentJson> avatar { get; set; }
    public Optional<DateTime> timeout { get; set; }
    public Optional<List<string>> remove { get; set; }

    /// <summary>
    /// Voice mute
    /// </summary>
    public Optional<bool> can_publish { get; set; }

    /// <summary>
    /// Voice deafen
    /// </summary>
    public Optional<bool> can_receive { get; set; }

    public Optional<string> voice_channel { get; set; }

    public void RemoveValue(string value)
    {
        if (!remove.HasValue)
            remove = Optional.Some(new List<string>());

        remove.Value.Add(value);
    }
}
