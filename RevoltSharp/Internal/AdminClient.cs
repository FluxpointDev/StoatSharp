namespace StoatSharp;

public class StoatAdminClient
{
    internal StoatAdminClient(StoatClient client)
    {
        Client = client;
    }
    internal StoatClient Client;
}
