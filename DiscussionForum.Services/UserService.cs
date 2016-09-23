using DiscussionForum.Domain.Interfaces.Services;
using System.Data;
using System.Linq;
using DiscussionForum.Domain.DomainModel;
using Dapper;

namespace DiscussionForum.Services
{
    public class UserService : IUserService
    {
        private IDbConnection _connection { get; set; }

        public UserService(IDbConnection connection)
        {
            _connection = connection;
        }

        public void RegisterUser(User user)
        {
            string query = @"INSERT INTO Users (Email, Username, Password, Confirmed, ConfirmationCode, Role, Birthdate, Datecreated, Fullname, Gender, Faculty, Country, Avatar, Bio)
                             values(@Email, @Username, @Password, @Confirmed, @ConfirmationCode, @Role, @Birthdate, @DateCreated, @Fullname, @Gender, @Faculty, @Country, @Avatar, @Bio)";
            _connection.Execute(query, new { user.Email, user.Username, user.Password, user.Confirmed, user.ConfirmationCode, user.Role, user.Birthdate, user.DateCreated, user.Fullname, user.Gender, user.Faculty, user.Country, user.Avatar, user.Bio });
        }


        public string CheckForExistingUser(string email)
        {
            string sql = $"SELECT * FROM Users WHERE Email='{email}'";
            var userExists = _connection.Query<User>(sql).FirstOrDefault();
            if (userExists != null)
            {
                return "User with that email already exists!";
            }

            return "";
        }

        public string CheckUserBeforeLogin(string email, string password)
        {
            string sql = $"SELECT * FROM Users WHERE Email='{email}'";
            var user = _connection.Query<User>(sql).FirstOrDefault();

            if (user == null)
                return "User with that email does not exists! Please register.";

            if (user.Confirmed == false)
                return "Your account is not confirmed! Please confirm your account.";

            if (user.Password != password)
                return "Wrong password!";

            return "";
        }

        public User GetUserByEmail(string email)
        {
            string sql = $"SELECT * FROM Users WHERE Email='{email}'";
            var user = _connection.Query<User>(sql).FirstOrDefault();
            return user;
        }

        public User GetUserByUsername(string username)
        {
            var sql = $@"SELECT * FROM Users
                         WHERE Users.Username = '{username}'";
            var user = _connection.Query<User>(sql).FirstOrDefault();

            return user;
        }

        public string ConfirmRegistration(string confirmationCode)
        {
            string sql = $"SELECT * FROM Users WHERE ConfirmationCode='{confirmationCode}'";
            var user = _connection.Query<User>(sql).FirstOrDefault();

            if (user != null)
            {
                user.Confirmed = true;
                string updateQuery = $"UPDATE Users SET Confirmed = '{user.Confirmed}' WHERE ID='{user.ID}'";
                _connection.Execute(updateQuery);
                return "Your account is confirmed!";
            }
            else
                return "User with that confirmation link does not exists!";
        }
    }
}
