namespace StoatSharp;

public class MessageWebhook
{
    internal MessageWebhook(StoatClient client, MessageWebhookJson model)
    {
        Name = model.Name;
        Avatar = Attachment.Create(client, model.Avatar);
    }


    public string Name;

    public Attachment? Avatar;
}