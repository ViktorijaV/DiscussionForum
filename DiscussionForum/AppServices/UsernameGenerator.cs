using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Web;
using System.Text.RegularExpressions;

namespace DiscussionForum.AppServices
{
    public class UsernameGenerator
    {
        private SqlConnection _connection { get; set; }

        public UsernameGenerator(SqlConnection connection)
        {
            _connection = connection;
        }

        public void addUsernameToUser(App_Code.User user)
        {
            var email = user.Email;
            var username = email.Split('@').First();
            username = Regex.Replace(username, "[^a-zA-Z0-9]", "-");

            var sql = $@"SELECT Username FROM Users WHERE Username LIKE @value";
            var usernames = _connection.Query<string>(sql, new { value = $"{username}%"}).ToList();
            int count = 1;
            var generatedUsername = username;
            while (usernames.Contains(generatedUsername))
            {
                generatedUsername = username + count;
                count++;
            }

            user.setUsername(generatedUsername);
        }
    }
}