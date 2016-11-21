namespace Voting.Web.Api.Controllers
{
    using System.Threading.Tasks;
    using Library.Ballot;
    using Library.Session;
    using Library.User;
    using Microsoft.AspNetCore.Mvc;

    public class BallotController : AuthorizationControllerBase
    {
        private readonly IBallotRepository ballotRepository;

        public BallotController(ISessionRepository sessionRepository, IUserRepository userRepository, IBallotRepository ballotRepository)
            : base(sessionRepository, userRepository)
        {
            this.ballotRepository = ballotRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBallots()
        {
            var user = await this.GetRequestUser();
            var ballots = await this.ballotRepository.Get(user.UserId);
            if (ballots != null)
            {
                return this.Ok(ballots);
            }
            else
            {
                return this.NotFound();
            }
        }


        [Route("{ballotId}")]
        [HttpGet]
        public async Task<IActionResult> GetBallot(int ballotId)
        {
            var user = await this.GetRequestUser();
            var ballot = await this.ballotRepository.Get(user.UserId, ballotId);
            if (ballot != null)
            {
                return this.Ok(ballot);
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}