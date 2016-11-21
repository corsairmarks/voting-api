namespace Voting.Web.Implementation.User
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Library.User;

    public class InMemoryUserRepository : IUserRepository
    {
        private readonly ISet<User> users;

        public InMemoryUserRepository()
        {
            this.users = new HashSet<User>();
        }

        public Task<bool> AddEmailAddress(int userId, string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(string username, string emailAddress, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(string usernameOrEmailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveEmailAddress(int userId, string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetUsername(int userId, string username)
        {
            throw new NotImplementedException();
        }
    }
}