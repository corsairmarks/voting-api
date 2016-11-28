namespace Voting.Web.Api.Tests.Utility
{
    using System;
    using System.Collections.Generic;
    using Api.Utility;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
    using Xunit;

    public class IHeaderDictionaryExtensionsTests
    {
        public static IEnumerable<> SessionTokens; // TODO: theory data

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
        [MemberData("SessionTokens")]
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
