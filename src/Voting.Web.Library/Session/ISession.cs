using System;

namespace Voting.Web.Library.Session
{
    public interface ISession
    {
        Guid SessionId { get; }

        DateTime RefreshedUtc { get; }

        int UserId { get; }
    }
}