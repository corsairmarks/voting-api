namespace Voting.Web.Api.Tests.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Api.Controllers;
    using Library.Session;
    using Library.User;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
    using Xunit;

    public class AuthorizationControllerBaseTests
    {
        //[Fact]
        //public async Task GetRequestUser_ReturnsUser()
        //{
        //    // Arrange
        //    var sessionRepositoryStub = new SessionRepositoryStub();
        //    var userRepositoryStub = new UserRepositoryStub();
        //    var target = new AuthorizationControllerBaseStub(sessionRepositoryStub, userRepositoryStub);
        //    var sessionId = Guid.NewGuid();
        //    target.HttpContext.Request.Headers.Add("X-SESSION-TOKEN", new StringValues(sessionId.ToString()));

        //    // Act
        //    var result = await target.PublicGetRequestUser();

        //    // Assert
        //    Assert.NotNull(result);
        //}

        //private class AuthorizationControllerBaseStub : AuthorizationControllerBase
        //{
        //    public AuthorizationControllerBaseStub(ISessionRepository sessionRepository, IUserRepository userRepository)
        //        : base(sessionRepository, userRepository)
        //    {

        //    }

        //    public Task<IUser> PublicGetRequestUser()
        //    {
        //        return this.GetRequestUser();
        //    }
        //}

        //private class UserRepositoryStub : IUserRepository
        //{
        //    public Task<bool> AddEmailAddress(int userId, string emailAddress)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int?> Create(string username, string emailAddress, string password)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<IUser> Get(string usernameOrEmailAddress)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<IUser> Get(int userId)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<bool> RemoveEmailAddress(int userId, string emailAddress)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<bool> SetUsername(int userId, string username)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //private class SessionRepositoryStub : ISessionRepository
        //{
        //    public Task<ISession> Create(int userId)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task Delete(Guid sessionId)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<ISession> Get(Guid sessionId)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<bool> Refresh(Guid sessionId)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
