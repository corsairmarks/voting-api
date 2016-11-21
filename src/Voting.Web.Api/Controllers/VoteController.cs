namespace Voting.Web.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class VoteController : AuthorizationControllerBase
    {
        public VoteController() { }

        [HttpPost]
        public async Task Vote()
        {

        }
    }
}