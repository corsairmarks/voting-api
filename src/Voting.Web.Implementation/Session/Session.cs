namespace Voting.Web.Implementation.Session
{
    using System;
    using Library.Session;

    /// <summary>
    /// A user session.
    /// </summary>
    internal class Session : ISession
    {
        public Session(Guid sessionId, DateTime refreshedUtc, int userId)
        {
            this.SessionId = sessionId;
            this.RefreshedUtc = refreshedUtc;
            this.UserId = userId;
        }

        public Guid SessionId { get; }

        public DateTime RefreshedUtc { get; }

        public int UserId { get; }
    }
}