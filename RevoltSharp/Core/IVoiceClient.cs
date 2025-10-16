using System.Threading.Tasks;

namespace StoatSharp;

public interface IVoiceClient
{
    Task StartAsync();

    Task StopAsync();
}