namespace Voting.Web.Library.Session
{
    using System;
    using System.Threading.Tasks;

    public interface ISessionDurationProvider
    {
        Task<TimeSpan> Get();
    }
}