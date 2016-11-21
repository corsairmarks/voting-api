namespace Voting.Web.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Filters;
    using Library.Authentication;
    using Library.Session;
    using Library.User;
    using Microsoft.AspNetCore.Mvc;

    [Controller]
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private readonly ISessionRepository sessionRepository;

        private readonly IUserRepository userRepository;

        private readonly IUserAuthenticationService userAuthenticationRepository;

        public SessionController(ISessionRepository sessionRepository, IUserRepository userRepository, IUserAuthenticationService userAuthenticationRepository)
        {
            this.sessionRepository = sessionRepository;
            this.userRepository = userRepository;
            this.userAuthenticationRepository = userAuthenticationRepository;
        }

        [HttpPost]
        public async Task<Guid?> LogIn(string usernameOrEmailAddress, string password)
        {
            var user = await this.userRepository.Get(usernameOrEmailAddress);
            if (user != null && await this.userAuthenticationRepository.ValidatePassword(user.UserId, password))
            {
                var session = await this.sessionRepository.Create(user.UserId);

                return session?.SessionId;
            }

            return null;
        }

        [Route("{sessionId}")]
        [HttpDelete]
        [ServiceFilter(typeof(TokenAuthorizationFilter))]
        public async Task LogOut(Guid sessionId)
        {
            await this.sessionRepository.Delete(sessionId);
        }
    }
}