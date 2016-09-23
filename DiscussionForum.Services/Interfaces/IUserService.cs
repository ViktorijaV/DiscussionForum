using DiscussionForum.Domain.DomainModel;

namespace DiscussionForum.Services.Intefraces
{
    public interface IUserService
    {
        void RegisterUser(User user);
        string CheckForExistingUser(string email);
        string CheckUserBeforeLogin(string email, string password);
        User GetUserByEmail(string email);
        User GetUserByUsername(string username);
        string ConfirmRegistration(string confirmationCode);
    }
}
