using Optionals;

namespace StoatSharp;


public class MessageMasquerade
{
    public MessageMasquerade(string name, string avatar = "", StoatColor color = null)
    {
        Name = name;
        AvatarUrl = avatar;
        Color = color == null ? new StoatColor("") : color;
    }
    private MessageMasquerade(MessageMasqueradeJson model)
    {
        Name = model.Name;
        AvatarUrl = model.AvatarUrl;
        if (model.Color.HasValue)
            Color = new StoatColor(model.Color.Value);
        else
            Color = new StoatColor("");
    }

    internal static MessageMasquerade? Create(MessageMasqueradeJson model)
    {
        if (model != null)
            return new MessageMasquerade(model);
        return null;
    }

    public string? Name { get; }
    public string? AvatarUrl { get; }
    public StoatColor Color { get; }

    internal MessageMasqueradeJson ToJson()
    {
        MessageMasqueradeJson Json = new MessageMasqueradeJson();
        if (!string.IsNullOrEmpty(Name))
            Json.Name = Name;

        if (!string.IsNullOrEmpty(AvatarUrl))
            Json.AvatarUrl = AvatarUrl;

        if (Color != null && Color.HasValue)
            Json.Color = Optional.Some(Color.Hex);

        return Json;
    }

    /// <summary> Returns a string that represents the current object.</summary>
    /// <returns> Masquerade name </returns>
    public override string ToString()
    {
        return Name ?? "Masquerade name";
    }
}