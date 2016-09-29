using System.Data;
using System.Linq;
using DiscussionForum.Domain.DomainModel;
using Dapper;
using DiscussionForum.Services.Intefraces;
using System;
using DiscussionForum.Services.DTOs;

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
            string query = @"INSERT INTO Users (Email, Username, Password, Confirmed, ConfirmationCode, Role, Birthdate, Datecreated, Fullname, Gender, Avatar, Bio, Blocked)
                             values(@Email, @Username, @Password, @Confirmed, @ConfirmationCode, @Role, @Birthdate, @DateCreated, @Fullname, @Gender, @Avatar, @Bio, @Blocked)";
            _connection.Execute(query, new { user.Email, user.Username, user.Password, user.Confirmed, user.ConfirmationCode, user.Role, user.Birthdate, user.DateCreated, user.Fullname, user.Gender, user.Avatar, user.Bio, user.Blocked });
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

            if (user.Blocked == true)
                return "Your account was blocked by the admins.";

            if (user.Password != password)
                return "Wrong password!";

            return "";
        }

        public User GetUserById(int id)
        {
            string sql = $"SELECT * FROM Users WHERE ID='{id}'";
            var user = _connection.Query<User>(sql).FirstOrDefault();
            return user;
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

        public void ChangeUserProperties(int id, string fullname, string bio, string avatar)
        {
            string sql = $"UPDATE Users SET FullName = '{fullname}', Bio = '{bio}', Avatar = '{avatar}' WHERE ID='{id}'";
            _connection.Execute(sql);
        }

        public void ChangePassword(int id, string newPassword)
        {
            string sql = $"UPDATE Users SET Password = '{newPassword}' WHERE ID='{id}'";
            _connection.Execute(sql);
        }

        public void ChangeUserConfirmationCode(string email, string code)
        {
            string sql = $"UPDATE Users SET ConfirmationCode = '{code}' WHERE Email='{email}'";
            _connection.Execute(sql);
        }

        public void BlockUser(string username)
        {
            var blocked = true;
            string sql = $"UPDATE Users SET Blocked = '{blocked}' WHERE Username='{username}'";
            _connection.Execute(sql);
        }

        public UserDTO GetUserDetails(int userID)
        {
            var sql = $@"SELECT 
                         Users.ID                   AS ID,
                         Users.Email                AS Email,
                         Users.Username             AS Username,
                         Users.Fullname             AS Fullname,
                         Users.Role                 AS Role,
                         Users.Gender               AS Gender,
                         Users.Birthdate            AS Birthdate,
                         Users.Avatar               AS Avatar,
                         Users.Bio                  AS Bio,
                         Users.Blocked              AS Blocked,
                         (SELECT COUNT(*)
                                FROM Topics
                                WHERE Topics.CreatorID = {userID})
                                                  AS NumTopics,
                         (SELECT COUNT(*)
                          FROM Comments
                          WHERE Comments.CommenterID = {userID})
                                                  AS NumComments
                         FROM Users
                         WHERE Users.ID = '{userID}'";
            var user = _connection.Query<UserDTO>(sql).FirstOrDefault();

            return user;
        }
    }
}
