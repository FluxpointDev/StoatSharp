using System.Collections.Generic;

namespace StoatSharp;

internal class UserMutualsJson
{
    public HashSet<string> users { get; set; }
    public HashSet<string> servers { get; set; }
}
