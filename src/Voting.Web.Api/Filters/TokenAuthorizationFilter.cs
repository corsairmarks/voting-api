namespace Voting.Web.Api.Filters
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Library.Session;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Primitives;

    public class TokenAuthorizationFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly ISessionRepository sessionRepository;

        private readonly ISessionDurationProvider sessionDurationProvider;

        public TokenAuthorizationFilter(ISessionRepository sessionRepository, ISessionDurationProvider sessionDurationProvider)
        {
            this.sessionRepository = sessionRepository;
            this.sessionDurationProvider = sessionDurationProvider;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var header = context.HttpContext.Request.Headers["X-AUTH-TOKEN"];

            Guid sessionId;
            if (header != StringValues.Empty && Guid.TryParse(header.First(), out sessionId))
            {
                var session = await this.sessionRepository.Get(sessionId);
                if (session != null && session.RefreshedUtc + await this.sessionDurationProvider.Get() >= DateTime.UtcNow)
                {
                    await this.sessionRepository.Refresh(sessionId);
                    return;
                }
            }

            context.Result = new UnauthorizedResult();
        }
    }
}