namespace StoatSharp;


public class SocketError
{
    public string? Message { get; internal set; }
    public StoatErrorType Type { get; internal set; }
}