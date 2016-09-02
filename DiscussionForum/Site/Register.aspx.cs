using System;
using DiscussionForum.App_Code;
using DiscussionForum.AppServices;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Linq;

namespace DiscussionForum.Site
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            User user;
            if (male.Checked == true)
                user = DiscussionForum.App_Code.User.RegisterUser(txtEmail.Text, txtFullName.Text, txtPassword.Text, txtRepeatPassword.Text, Gender.Male, Convert.ToDateTime(txtBirthday.Text), ConfigurationManager.AppSettings["profileAvatarUrl"]);
            else
                user = DiscussionForum.App_Code.User.RegisterUser(txtEmail.Text, txtFullName.Text, txtPassword.Text, txtRepeatPassword.Text, Gender.Female, Convert.ToDateTime(txtBirthday.Text), ConfigurationManager.AppSettings["profileAvatarUrl"]);


            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());

            if (checkForExistingUser(connection, txtEmail.Text))
                return;

            sendEmail(user.ConfirmationCode, user.Email);

            var usernameGenerator = new UsernameGenerator(connection);
            usernameGenerator.addUsernameToUser(user);

            registerUser(connection, user);

            Response.Redirect("confirmation");
        }

        private bool checkForExistingUser(SqlConnection connection, string email)
        {
            string sql = $"SELECT * FROM Users WHERE Email='{email}'";
            var userExists = connection.Query<User>(sql).FirstOrDefault();
            if (userExists != null)
            {
                error.InnerText = "User with that email already exists!";
                return true;
            }

            return false;
        }

        private void sendEmail(string confirmationCode, string email)
        {
            string message = $@"Please click on the link to confirm your registration: 
                <a href='http://{ConfigurationManager.AppSettings["domainName"]}/confirmation?code={confirmationCode}'>Link</a>";
            EMailSender.SendEmail("Confirm your registration", message, email);
        }

        private void registerUser(SqlConnection connection, User user)
        {
            string query = @"INSERT INTO Users (Email, Username, Password, Confirmed, ConfirmationCode, Role, Birthdate, Datecreated, Fullname, Gender, Faculty, Country, Avatar, Bio)
                             values(@Email, @Username, @Password, @Confirmed, @ConfirmationCode, @Role, @Birthdate, @DateCreated, @Fullname, @Gender, @Faculty, @Country, @Avatar, @Bio)";
            connection.Execute(query, new { user.Email, user.Username, user.Password, user.Confirmed, user.ConfirmationCode, user.Role, user.Birthdate, user.DateCreated, user.Fullname, user.Gender, user.Faculty, user.Country, user.Avatar, user.Bio });
        }
    }
}