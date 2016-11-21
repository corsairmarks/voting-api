namespace Voting.Web.Library.Ballot
{
    using System.Collections.Generic;

    public interface IBallotQuestion
    {
        int QuestionId { get; }

        string Description { get; }

        int MaximumSelectableOptions { get; }

        IReadOnlyList<IBallotQuestionOption> Options { get; }
    }
}