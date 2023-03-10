using System;
using System.Net;
using Voltaic;

namespace Akitaux.Twitch.Rest
{
    public class TwitchRestException : Exception
    {
        public HttpStatusCode HttpCode { get; }
        public int? DiscordCode { get; }
        public Utf8String Reason { get; }

        public TwitchRestException(HttpStatusCode httpCode, int? discordCode = null, Utf8String reason = null)
            : base(CreateMessage(httpCode, discordCode, reason))
        {
            HttpCode = httpCode;
            DiscordCode = discordCode;
            Reason = reason;
        }

        private static string CreateMessage(HttpStatusCode httpCode, int? discordCode = null, Utf8String reason = null)
        {
            if (!(reason is null) && reason.Bytes.Length > 0)
                return $"The server responded with error {discordCode ?? (int)httpCode}: {reason.ToString()}";
            else
                return $"The server responded with error {discordCode ?? (int)httpCode}: {httpCode.ToString()}";
        }
    }
}
