namespace Voting.Web.Implementation.Session
{
    using System;
    using System.Threading.Tasks;
    using Library.Session;

    public class InMemorySessionRepository : ISessionRepository
    {
        public Task<ISession> Create(int userId)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<ISession> Get(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public Task Refresh(Guid sessionId)
        {
            throw new NotImplementedException();
        }
    }
}