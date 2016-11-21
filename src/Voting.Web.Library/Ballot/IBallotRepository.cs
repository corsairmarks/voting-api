using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voting.Web.Library.Ballot
{
    public interface IBallotRepository
    {
        Task<IReadOnlyCollection<IBallot>> Get();

        Task<IReadOnlyCollection<IBallot>> Get(int userId);

        Task<IBallot> Get(int userId, int ballotId);

        // Ideally there would be methods here for administrator(s) to create new ballots or update existing ballots
    }
}
