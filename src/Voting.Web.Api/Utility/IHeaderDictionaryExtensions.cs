namespace Voting.Web.Api.Utility
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;

    public static class IHeaderDictionaryExtensions
    {
        public static Guid? GetSessionToken(this IHeaderDictionary headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            var header = headers["X-SESSION-TOKEN"];
            Guid authorizationToken;
            if (header != StringValues.Empty && Guid.TryParse(header.First(), out authorizationToken))
            {
                return authorizationToken;
            }

            return null;
        }
    }
}