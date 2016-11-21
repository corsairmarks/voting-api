namespace Voting.Web.Api.Filters
{
    using System;
    using Library.Session;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class TokenAuthorizationFilterFactory : IFilterFactory
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var sessionRepository = (ISessionRepository)serviceProvider.GetService(typeof(ISessionRepository));

            return new TokenAuthorizationFilter(sessionRepository);
        }
    }
}