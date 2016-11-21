namespace Voting.Web.Library.Authentication
{
    using System.Threading.Tasks;

    public interface IUserAuthenticationService
    {
        Task<bool> ValidatePassword(int userId, string password);

        Task SetPassword(int userId, string password);
    }
}