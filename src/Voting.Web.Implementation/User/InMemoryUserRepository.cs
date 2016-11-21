namespace Voting.Web.Implementation.User
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Library.User;
    using Library.Authentication;

    public class InMemoryUserRepository : IUserRepository, IUserAuthenticationService
    {
        private readonly ISet<IUser> users;

        public InMemoryUserRepository()
        {
            this.users = new HashSet<IUser>
            {
                new User
                {
                    UserId = 1,
                    Username = "default",
                    EmailAddresses = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "default@example.com", },
                    PasswordHash = "pass1234",
                },
            };
        }

        public async Task<bool> AddEmailAddress(int userId, string emailAddress)
        {
            var existingUser = await this.Get(userId);
            if (existingUser != null)
            {
                existingUser.EmailAddresses.Add(emailAddress);

                return true;
            }

            return false;
        }

        public Task<int?> Create(string username, string emailAddress, string password)
        {
            var existingUser = this.users.SingleOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
            if (existingUser == null)
            {
                var maxUserId = this.users.Max(u => u.UserId);
                users.Add(new User
                {
                    UserId = maxUserId + 1,
                    Username = username,
                    EmailAddresses = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { emailAddress, },
                });

                return Task.FromResult<int?>(maxUserId);
            }

            return Task.FromResult<int?>(null);
        }

        public Task<IUser> Get(string username)
        {
            var existingUser = this.users.SingleOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
            if (existingUser != null)
            {
                return Task.FromResult(existingUser);
            }

            return Task.FromResult<IUser>(null);
        }

        public Task<IUser> Get(int userId)
        {
            return Task.FromResult(this.users.SingleOrDefault(u => u.UserId == userId));
        }

        public async Task<bool> RemoveEmailAddress(int userId, string emailAddress)
        {
            var existingUser = await this.Get(userId);
            if (existingUser != null)
            {
                existingUser.EmailAddresses.Remove(emailAddress);

                return true;
            }

            return false;
        }

        public async Task<bool> SetUsername(int userId, string username)
        {
            var existingUserById = await this.Get(userId);
            var existingUserByUsername = await this.Get(username);
            if (existingUserById != null && existingUserByUsername == null)
            {
                existingUserById.Username = username;

                return true;
            }

            return false;
        }

        public async Task SetPassword(int userId, string password)
        {
            var existingUser = (User)await this.Get(userId);
            if (existingUser != null)
            {
                // This is SERIOUSLY INSECURE and meant as an easy implementation for demonstrating a functioning application.  Use bcrypt or a secure, well-evaluated alternative in a real implementation.
                existingUser.PasswordHash = password;
            }
        }

        public async Task<bool> ValidatePassword(int userId, string password)
        {
            var existingUser = (User)await this.Get(userId);
            if (existingUser != null)
            {
                return string.Equals(existingUser.PasswordHash, password, StringComparison.Ordinal);
            }

            return false;
        }
    }
}