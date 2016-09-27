using DiscussionForum.Domain.DomainModel;

namespace DiscussionForum.Services.Intefraces
{
    public interface IUserService
    {
        void RegisterUser(User user);
        string CheckForExistingUser(string email);
        string CheckUserBeforeLogin(string email, string password);
        User GetUserById(int id);
        User GetUserByEmail(string email);
        User GetUserByUsername(string username);
        string ConfirmRegistration(string confirmationCode);
        void ChangeUserProperties(int id, string fullname, string bio, string avatar);
        void ChangePassword(int id, string newPassword);
        void ChangeUserConfirmationCode(string email, string code);
    }
}
