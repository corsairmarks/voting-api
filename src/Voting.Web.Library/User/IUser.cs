using System.Collections.Generic;

namespace Voting.Web.Library.User
{
    public interface IUser
    {
        int UserId { get; }

        string Username { get; set; }

        ISet<string> EmailAddresses { get; set; }
    }
}