namespace Voting.Web.Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Library.Session;
    using Library.User;
    using Library.Vote;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Utility;

    [Route("{ballotId}")]
    public class VoteController : AuthorizationControllerBase
    {


        private readonly IVoteRepository voteRepository;

        public VoteController(ISessionRepository sessionRepository, IUserRepository userRepository, IVoteRepository voteRepository)
            : base(sessionRepository, userRepository)
        {
            this.voteRepository = voteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetVotes(int ballotId)
        {
            var user = await this.GetRequestUser();
            var votes = await this.voteRepository.Get(user.UserId, ballotId);
            if (votes != null && votes.Any())
            {
                return this.Ok(votes);
            }

            return this.NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Vote(int ballotId, Vote[] votes)
        {
            var user = await this.GetRequestUser();
            // Normally, there would be validation here
            if (ModelState.IsValid)
            {
                await this.voteRepository.Set(user.UserId, ballotId, votes);
            }

            return this.BadRequest();
        }
    }
}