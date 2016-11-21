namespace Voting.Web.Implementation.User
{
    using System.Collections.Generic;
    using Library.User;

    internal class User : IUser
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public ISet<string> EmailAddresses { get; set; }

        public string PasswordHash { get; set; }
    }
}