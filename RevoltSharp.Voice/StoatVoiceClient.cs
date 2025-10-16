using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace StoatSharp;

public class StoatVoiceClient : IVoiceClient
{
    public StoatVoiceClient(StoatClient client)
    {
        Client = client;
    }

    internal StoatClient Client;

    public ConcurrentDictionary<string, VoiceState> Channels { get; internal set; } = new ConcurrentDictionary<string, VoiceState>();

    public async Task StartAsync()
    {
        Client.Logger.LogMessage("Connecting to Voice Server", StoatLogSeverity.Info);

        //var Req = await Client.Rest.SendRequestAsync(Rest.RequestType.Get, Client.Config.Debug.VoiceServerUrl);
        //if (Req.IsSuccessStatusCode)
        //    Client.Logger.LogMessage("Connected to Voice Server!", StoatLogSeverity.Info);
        //else
        //    Client.Logger.LogMessage("Failed to connect to Voice Server", StoatLogSeverity.Warn);



    }

    public async Task StopAsync()
    {
        Client.Logger.LogMessage("Disconnecting from Voice Server", StoatLogSeverity.Info);

        foreach (VoiceState s in Channels.Values)
        {
            await s.StopAsync();
            Channels.TryRemove(s.Channel.Id, out _);
        }
    }
}