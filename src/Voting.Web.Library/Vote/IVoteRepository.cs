namespace Voting.Web.Library.Vote
{
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IVoteRepository
    {
        Task<IReadOnlyCollection<IVote>> Get(int userId, int ballotId);

        Task Set(int userId, int ballotId, IReadOnlyCollection<IVote> votes);
    }
}