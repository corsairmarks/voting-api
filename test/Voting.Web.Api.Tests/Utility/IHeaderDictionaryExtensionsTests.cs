namespace Voting.Web.Api.Tests.Utility
{
    using System;
    using Api.Utility;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
    using Xunit;

    public class IHeaderDictionaryExtensionsTests
    {
        private static readonly Guid RealGuid = Guid.Parse("c3f21140-064d-41d1-bc2b-ab0761a16a1f");

        public static TheoryData<string, Guid?> SessionTokens { get; } = new TheoryData<string, Guid?>
        {
            { null, null },
            { "", null },
            { "FOO", null },
            { "guid", null },
            { RealGuid.ToString(), RealGuid },
        };

        [Fact]
        public void GetSessionToken_NullHeaders_Throws()
        {
            //  Arrange
            IHeaderDictionary target = null;

            //IHeaderDictionaryExtensions.GetSessionToken(null);

            // Act
            var expected = Assert.Throws<ArgumentNullException>(() => target.GetSessionToken());

            // Assert
            Assert.Equal(expected.ParamName, "headers");
        }

        [Theory]
        [MemberData(nameof(SessionTokens))]
        // NOTE: Because Guid is not serializable by default, Xunit can't output one line per test - I will be opening an issue on github
        public void GetSessionHeader_Values(string header, Guid? expected)
        {
            // Arrange
            var target = new HeaderDictionary();
            target.Add("X-SESSION-TOKEN", new StringValues(header));

            // Assert
            var result = target.GetSessionToken();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}