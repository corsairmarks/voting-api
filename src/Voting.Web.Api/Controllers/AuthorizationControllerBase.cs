namespace Voting.Web.Api.Controllers
{
    using System.Threading.Tasks;
    using Filters;
    using Library.Session;
    using Library.User;
    using Microsoft.AspNetCore.Mvc;
    using Utility;

    [Controller]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(TokenAuthorizationFilter))]
    public abstract class AuthorizationControllerBase : Controller
    {
        public AuthorizationControllerBase(ISessionRepository sessionRepository, IUserRepository userRepository)
        {
            this.SessionRepository = sessionRepository;
            this.UserRepository = userRepository;
        }

        protected ISessionRepository SessionRepository { get; }

        protected IUserRepository UserRepository { get; }

        protected async Task<IUser> GetRequestUser()
        {
            var sessionToken = this.HttpContext.Request.Headers.GetSessionToken();
            var session = sessionToken.HasValue
                ? await this.SessionRepository.Get(sessionToken.Value)
                : null;
            return session != null
                ? await this.UserRepository.Get(session.UserId)
                : null;
        }
    }
}