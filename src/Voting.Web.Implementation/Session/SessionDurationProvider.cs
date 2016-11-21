namespace Voting.Web.Implementation.Session
{
    using System;
    using System.Threading.Tasks;
    using Library.Session;

    public class SessionDurationProvider : ISessionDurationProvider
    {
        private readonly TimeSpan sessionDuration;

        public SessionDurationProvider(TimeSpan sessionDuration)
        {
            this.sessionDuration = sessionDuration;
        }

        public Task<TimeSpan> Get()
        {
            return Task.FromResult(this.sessionDuration);
        }
    }
}