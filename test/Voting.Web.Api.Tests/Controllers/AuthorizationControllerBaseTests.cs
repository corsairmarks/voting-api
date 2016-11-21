namespace Voting.Web.Api.Tests.Controllers
{
    using System.Threading.Tasks;
    using Api.Controllers;
    using Library.Session;
    using Library.User;
    using Xunit;

    public class AuthorizationControllerBaseTests
    {
        [Fact]
        public async Task GetRequestUser_ReturnsUser()
        {
            // Arrange
            var target = new AuthorizationControllerBaseStub(null, null);

            // Act
            var result = await target.StubMethod();

            // Assert
            Assert.NotNull(result);
        }

        private class AuthorizationControllerBaseStub : AuthorizationControllerBase
        {
            public AuthorizationControllerBaseStub(ISessionRepository sessionRepository, IUserRepository userRepository)
                : base(sessionRepository, userRepository)
            {

            }

            public Task<IUser> StubMethod()
            {
                return this.GetRequestUser();
            }
        }
    }
}
