using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voting.Web.Library.User
{
    public interface IUserRepository
    {
        Task<IUser> Get(int userId);

        Task<IUser> Get(string usernameOrEmailAddress);

        Task<int?> Create(string username, string emailAddress, string password);

        Task<bool> SetUsername(int userId, string username);

        Task<bool> AddEmailAddress(int userId, string emailAddress);

        Task<bool> RemoveEmailAddress(int userId, string emailAddress);
    }
}