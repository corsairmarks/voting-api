namespace Voting.Web.Api.Controllers
{
    using Filters;
    using Microsoft.AspNetCore.Mvc;

    [Controller]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(TokenAuthorizationFilter))]
    public abstract class AuthorizationControllerBase : Controller
    {
    }
}