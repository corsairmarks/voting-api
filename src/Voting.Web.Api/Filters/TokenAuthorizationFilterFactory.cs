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
            var context = (ISessionRepository)serviceProvider.GetService(typeof(ISessionRepository));
            var sessionDurationProvider = (ISessionDurationProvider)serviceProvider.GetService(typeof(ISessionDurationProvider));

            return new TokenAuthorizationFilter(context, sessionDurationProvider);
        }
    }
}