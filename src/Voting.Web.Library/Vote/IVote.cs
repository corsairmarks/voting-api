namespace Voting.Web.Library.Vote
{
    using System.Collections.Generic;

    public interface IVote
    {
        int QuestionId { get; set; }

        IReadOnlyList<int> OptionIds { get; set; }
    }
}