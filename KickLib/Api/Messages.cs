using KickLib.Core;
using KickLib.Interfaces;
using Microsoft.Extensions.Logging;

namespace KickLib.Api;

public class Messages : BaseApi
{
    private const string ApiUrlPart = "messages/";

    public Messages(IApiCaller client, ILogger logger = null)
        : base(client, logger)
    {
    }

    /// <summary>
    ///     Sends message to chatroom. [Requires authentication].
    /// </summary>
    /// <param name="chatroomId">Chatroom ID where to send the message.</param>
    /// <param name="message">Message to be send.</param>
    public async Task SendMessageAsync(int chatroomId, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentNullException(nameof(message));
        }
        
        var urlPart = $"{ApiUrlPart}send/{chatroomId}";

        var payload = new
        {
            content = message,
            type = "message"
        };
        
        await PostAuthenticatedAsync(urlPart, ApiVersion.V2, payload);
    }
}