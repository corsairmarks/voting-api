namespace Voting.Web.Api.Models
{
    using System.Collections.Generic;
    using Library.Vote;

    public class Vote : IVote
    {
        public int QuestionId { get; set; }

        public IReadOnlyList<int> OptionIds { get; set; }
    }
}