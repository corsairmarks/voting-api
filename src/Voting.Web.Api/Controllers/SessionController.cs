namespace Voting.Web.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Filters;
    using Library.Authentication;
    using Library.Session;
    using Library.User;
    using Microsoft.AspNetCore.Mvc;
    using Utility;

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
        public async Task<IActionResult> LogIn(string username, string password)
        {
            var user = await this.userRepository.Get(username);
            if (user != null && await this.userAuthenticationRepository.ValidatePassword(user.UserId, password))
            {
                var session = await this.sessionRepository.Create(user.UserId);

                return this.Ok(session?.SessionId);
            }

            return this.Unauthorized();
        }

        [Route("{sessionId}")]
        [HttpDelete]
        [ServiceFilter(typeof(TokenAuthorizationFilter))]
        public async Task<IActionResult> LogOut(Guid sessionId)
        {
            var sessionToken = this.HttpContext.Request.Headers.GetSessionToken();
            var tokenSession = sessionToken.HasValue
                ? await this.sessionRepository.Get(sessionToken.Value)
                : null;
            if (tokenSession != null)
            {
                var sessionToDelete = await this.sessionRepository.Get(sessionId);
                if (sessionToDelete != null && tokenSession.UserId == sessionToDelete.UserId)
                {
                    await this.sessionRepository.Delete(sessionId);
                    return this.NoContent();
                }
                else
                {
                    return this.NotFound();
                }
            }

            return this.Unauthorized();
        }
    }
}