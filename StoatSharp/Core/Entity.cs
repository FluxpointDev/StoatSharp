using Newtonsoft.Json;
using System;

namespace StoatSharp;

/// <summary>
/// A Stoat object entity that has the client attached.
/// </summary>
public abstract class Entity
{
    [JsonIgnore]
    internal StoatClient Client { get; }

    internal Entity(StoatClient client)
    {
        Client = client;
    }
}

/// <summary>
/// A Stoat object entity that has an ID, Created date and Client.
/// </summary>
public abstract class CreatedEntity : Entity
{
    internal CreatedEntity(StoatClient client, string id) : base(client)
    {
        Id = id;
        if (Id.Length > 3 && Ulid.TryParse(Id, out Ulid UID))
            CreatedAt = UID.Time;
    }

    /// <summary>
    /// Id of the object.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Date of when the object was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
}