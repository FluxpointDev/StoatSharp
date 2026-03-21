namespace StoatSharp;
public class SafetyUserStrike : CreatedEntity
{
    internal SafetyUserStrike(StoatClient client, SafetyUserStrikeJson model) : base(client, model.Id)
    {
        UserId = model.Id;
        Reason = model.Reason;
    }

    public string UserId { get; internal set; }

    public string Reason { get; internal set; }
}
