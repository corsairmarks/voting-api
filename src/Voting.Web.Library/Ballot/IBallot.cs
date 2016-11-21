namespace Voting.Web.Library.Ballot
{
    using System;
    using System.Collections.Generic;

    public interface IBallot
    {
        DateTime EndDateUtc { get; }

        int BallotId { get; }

        IReadOnlyList<IBallotQuestion> BallotQuestions { get; }
    }
}