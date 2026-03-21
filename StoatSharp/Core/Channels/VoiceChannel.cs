namespace StoatSharp;


/// <summary>
/// Channel that members can speak in to other members
/// </summary>
public class VoiceChannel : ServerChannel
{
    internal VoiceChannel(StoatClient client, ChannelJson model)
        : base(client, model)
    {
        Type = ChannelType.Voice;
    }
}