namespace StoatSharp.Rest;


/// <summary>
/// Send a custom json body request to the Stoat instance API<br /><br />
/// Use <see cref="StoatRestClient.SendRequestAsync(RequestType, string, IStoatRequest)"/> or <see cref="StoatRestClient.SendRequestAsync{TResponse}(RequestType, string, IStoatRequest, bool)"/>
/// </summary>
public interface IStoatRequest { }