namespace Voting.Web.Implementation.Authentication
{
    using System;
    using System.Threading.Tasks;
    using Library.Authentication;

    public class InMemoryUserAuthenticationService : IUserAuthenticationService
    {
        public Task SetPassword(int userId, string password)
        {
            throw new NotImplementedException("demo");
        }

        public Task<bool> ValidatePassword(int userId, string password)
        {
            return Task.FromResult(false);
        }
    }
}