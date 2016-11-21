namespace Voting.Web.Implementation.Ballot
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Library.Ballot;

    public class HardCodedBallotRepository : IBallotRepository
    {
        private readonly IBallot theBallot = new Ballot
        {
            BallotId = 1,
            EndDateUtc = new DateTime(2016, 12, 2, 1, 0, 0, DateTimeKind.Utc), // UTC 1am the next day == 9pm EST, on this date
            BallotQuestions = new ReadOnlyCollection<IBallotQuestion>(new[]
            {
                new BallotQuestion
                {
                    QuestionId = 1,
                    Description = "Should Mount Rushmore be relocated?",
                    MaximumSelectableOptions = 1,
                    Options = new ReadOnlyCollection<IBallotQuestionOption>(new[]
                    {
                        new BallotQuestionOption
                        {
                            OptionId = 1,
                            Title = "Yes",
                            Description = "Mount Rushmore should be relocated",
                        },
                        new BallotQuestionOption
                        {
                            OptionId = 2,
                            Title = "No",
                            Description = "Mount Rushmore should be remain",
                        },
                    }),
                },
            }),
        };

        public Task<IReadOnlyCollection<IBallot>> Get()
        {
            return Task.FromResult<IReadOnlyCollection<IBallot>>(new ReadOnlyCollection<IBallot>(new[] { this.theBallot, }));
        }

        public Task<IReadOnlyCollection<IBallot>> Get(int userId)
        {
            return Task.FromResult<IReadOnlyCollection<IBallot>>(new ReadOnlyCollection<IBallot>(new[] { this.theBallot, }));
        }

        public Task<IBallot> Get(int userId, int ballotId)
        {
            return Task.FromResult(this.theBallot);
        }

        private class Ballot : IBallot
        {
            public DateTime EndDateUtc { get; set; }

            public int BallotId { get; set; }

            public IReadOnlyList<IBallotQuestion> BallotQuestions { get; set; }
        }

        private class BallotQuestion : IBallotQuestion
        {
            public int QuestionId { get; set; }

            public string Description { get; set; }

            public int MaximumSelectableOptions { get; set; }

            public IReadOnlyList<IBallotQuestionOption> Options { get; set; }
        }

        private class BallotQuestionOption : IBallotQuestionOption
        {
            public int OptionId { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public string Value { get; set; }
        }
    }
}