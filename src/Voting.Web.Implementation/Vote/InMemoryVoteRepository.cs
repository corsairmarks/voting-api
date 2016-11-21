namespace Voting.Web.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Library.Vote;

    public class InMemoryVoteRepository : IVoteRepository
    {
        private readonly IDictionary<Tuple<int, int>, List<IVote>> allVotes = new Dictionary<Tuple<int, int>, List<IVote>>();

        public Task<IReadOnlyCollection<IVote>> Get(int userId, int ballotId)
        {
            List<IVote> votes;
            if (this.allVotes.TryGetValue(Tuple.Create(userId, ballotId), out votes) && votes != null)
            {
                return Task.FromResult<IReadOnlyCollection<IVote>>(votes);
            }

            return Task.FromResult<IReadOnlyCollection<IVote>>(new List<IVote>());
        }

        public Task Set(int userId, int ballotId, IReadOnlyCollection<IVote> votes)
        {
            this.allVotes[Tuple.Create(userId, ballotId)] = votes.ToList();

            return Task.CompletedTask;
        }
    }
}