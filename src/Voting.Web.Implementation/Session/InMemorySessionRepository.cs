namespace Voting.Web.Implementation.Session
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Library.Session;

    public class InMemorySessionRepository : ISessionRepository
    {
        private readonly ISessionDurationProvider sessionDurationProvider;

        private readonly IDictionary<Guid, ISession> sessions = new Dictionary<Guid, ISession>();

        public InMemorySessionRepository(ISessionDurationProvider sessionDurationProvider)
        {
            this.sessionDurationProvider = sessionDurationProvider;
        }

        public Task<ISession> Create(int userId)
        {
            var sessionId = Guid.NewGuid();
            var session = this.sessions[sessionId] = new Session(sessionId, DateTime.UtcNow, userId);
            return Task.FromResult(session);
        }

        public Task Delete(Guid sessionId)
        {
            if (this.sessions.ContainsKey(sessionId))
            {
                this.sessions.Remove(sessionId);
            }

            return Task.CompletedTask;
        }

        public Task<ISession> Get(Guid sessionId)
        {
            ISession session;
            if (this.sessions.TryGetValue(sessionId, out session))
            {
                return Task.FromResult(session);
            }

            return Task.FromResult<ISession>(null);
        }

        public async Task<bool> Refresh(Guid sessionId)
        {
            var session = (Session)await this.Get(sessionId);
            if (session != null && session.RefreshedUtc + await this.sessionDurationProvider.Get() >= DateTime.UtcNow)
            {
                session.RefreshedUtc = DateTime.UtcNow;
                return true;
            }

            return false;
        }
    }
}