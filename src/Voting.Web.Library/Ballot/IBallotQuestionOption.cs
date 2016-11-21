namespace Voting.Web.Library.Ballot
{
    public interface IBallotQuestionOption
    {
        int OptionId { get; }

        string Title { get; }

        string Description { get; }

        string Value { get; }
    }
}