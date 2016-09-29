using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services.DTOs;

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
        UserDTO GetUserDetails(int userID);
        string ConfirmRegistration(string confirmationCode);
        void ChangeUserProperties(int id, string fullname, string bio, string avatar);
        void ChangePassword(int id, string newPassword);
        void ChangeUserConfirmationCode(string email, string code);
        void BlockUser(string username);
    }
}
