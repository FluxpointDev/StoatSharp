using Optionals;
using System;

namespace StoatSharp;


internal static class ModelExtensions
{
    internal static T ToEnum<T>(this string value, bool ignoreCase = true)
    {
        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }
    internal static Optional<Attachment?> ToModel(this Optional<AttachmentJson> json, StoatClient client)
    {
        if (!json.HasValue)
            return Optional.None<Attachment?>();

        return Optional.Some(json.Value.ToModel(client));
    }

    internal static Attachment? ToModel(this AttachmentJson json, StoatClient client)
    {
        if (json == null)
            return null;

        return Attachment.Create(client, json);
    }
}
