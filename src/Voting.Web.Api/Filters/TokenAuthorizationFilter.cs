namespace Voting.Web.Api.Filters
{
    using System;
    using System.Threading.Tasks;
    using Library.Session;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Utility;

    public class TokenAuthorizationFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly ISessionRepository sessionRepository;

        public TokenAuthorizationFilter(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var sessionId = context.HttpContext.Request.Headers.GetSessionToken();
            if (sessionId.HasValue && await this.sessionRepository.Refresh(sessionId.Value))
            {
                return;
            }

            context.Result = new UnauthorizedResult();
        }
    }
}