using DiscussionForum.Domain.DomainModel;

namespace DiscussionForum.Domain.Interfaces.Services
{
    public interface IUserService
    {
        void RegisterUser(User user);
        string CheckForExistingUser(string email);
        string LoginUser(string email, string password, bool extendExpirationDate);
        User GetUserByUsername(string username);
        string ConfirmRegistration(string confirmationCode);
        void LogoutUser();
    }
}
