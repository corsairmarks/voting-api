namespace Voting.Web.Library.Session
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The session repository.
    /// </summary>
    public interface ISessionRepository
    {
        /// <summary>
        /// Create a session for the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The user for whom to create a session.</param>
        /// <returns>An asynchronous task that returns the new <see cref="Session"/>.</returns>
        Task<ISession> Create(int userId);

        /// <summary>
        /// Get the <see cref="Session"/> with the specified <paramref name="sessionId"/>.
        /// </summary>
        /// <param name="sessionId">The session to retrieve.</param>
        /// <returns>An asynchronous task that returns the <see cref="Session"/> with the speccified <paramref name="sessionId"/> if it exists; otherwise, <c>null</c>.</returns>
        Task<ISession> Get(Guid sessionId);

        /// <summary>
        /// Refresh the expiration date for the specified <paramref name="sessionId"/>.
        /// </summary>
        /// <param name="sessionId">The session to refresh.</param>
        /// <returns>An asynchronous task that returns when work is complete.</returns>
        Task Refresh(Guid sessionId);

        /// <summary>
        /// Deletes the session with the specified <paramref name="sessionId"/>.
        /// </summary>
        /// <param name="sessionId">The session to delete.</param>
        /// <returns>An asynchronous task that returns when work is complete.</returns>
        Task Delete(Guid sessionId);
    }
}