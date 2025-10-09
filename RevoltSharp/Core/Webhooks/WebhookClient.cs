using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace RevoltSharp;

public class StoatWebhookClient
{
    public static readonly Regex WebhookUrlRegex = new Regex(@"^(https|http)\:\/\/[a-zA-Z\d-]+\.[a-zA-Z\d-]+\/api\/webhooks\/([0-7][0-9A-HJKMNP-TV-Z]{25})\/(.*)$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

    public StoatWebhookClient(RevoltClient client, string webhookUrl)
    {
        if (client == null)
            throw new RevoltArgumentException("Revolt client for webhook is missing.");
        ParseWebhookUrl(webhookUrl, out string id, out string token);

        Client = client;
        Url = webhookUrl;
        Id = id;
        Token = token;
    }

    [JsonIgnore]
    internal RevoltClient Client { get; }

    public string Url { get; internal set; }

    public string Id { get; private set; }

    public string Token { get; private set; }

    public static void ParseWebhookUrl(string webhookUrl, out string webhookId, out string webhookToken)
    {
        if (string.IsNullOrEmpty(webhookUrl))
            throw new RevoltArgumentException("Webhook url is missing.");


        RevoltArgumentException ex(string reason = null)
            => new RevoltArgumentException($"The webhook url format is invalid. {reason}");

        Match match = WebhookUrlRegex.Match(webhookUrl);

        if (match != null)
        {
            // ensure that the first group is a ulong, set the _webhookId
            // 0th group is always the entire match, and 1 is the domain; so start at index 2
            if (!(match.Groups[2].Success))
                throw ex("The webhook Id could not be parsed.");

            webhookId = match.Groups[2].Value;

            if (!match.Groups[3].Success)
                throw ex("The webhook token could not be parsed.");
            webhookToken = match.Groups[3].Value;
        }
        else
            throw ex("The webhook url could not be parsed.");
    }
}
