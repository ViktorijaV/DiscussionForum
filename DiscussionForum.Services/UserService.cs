using DiscussionForum.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscussionForum.Domain.DomainModel;
using Dapper;

namespace DiscussionForum.Services
{
    public class UserService : IUserService
    {
        private IDbConnection _connection { get; set; }
        //private IEmailSender _emailSender { get; set; }

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
    }
}
