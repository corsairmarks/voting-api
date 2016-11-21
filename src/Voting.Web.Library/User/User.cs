using System.Collections.Generic;

namespace Voting.Web.Library.User
{
    public class User
    {
        public int UserId { get; }

        public string Username { get; set; }

        public ISet<string> EmailAddresses { get; set; }
    }
}