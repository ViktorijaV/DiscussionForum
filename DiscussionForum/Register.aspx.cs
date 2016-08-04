using System;
using DiscussionForum.App_Code;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace DiscussionForum
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("localhost:54296/Confirmation.aspx");
            //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            //string sql = "sql command ...";
            //var user = connection.Query<User>(sql);

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            User user;
            if (male.Checked == true)
                user = DiscussionForum.App_Code.User.RegisterUser(txtEmail.Text, txtFullName.Text, txtPassword.Text, txtRepeatPassword.Text, Gender.Male, Convert.ToDateTime(txtBirthday.Text));
            else
                user = DiscussionForum.App_Code.User.RegisterUser(txtEmail.Text, txtFullName.Text, txtPassword.Text, txtRepeatPassword.Text, Gender.Female, Convert.ToDateTime(txtBirthday.Text));

            string message = "Please click on the link to confirm your registretion: " +
                "<a href=\"localhost:54296/Confirmation.aspx?code=" + user.RegistrationConfirmationCode + "\" >Link</a>";
            EMailSender.SendEmail("Confirm your registration", message, user.Email);

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            string query = "INSERT INTO Users (Username, Password, Confirmed, Role, Birthdate, Datecreated, Email, Fullname, Gender, Faculty, Country, Avatar)" +
                "values(@Username, @Password, @IsConfirmed, @Role, @Birthday, @DateCreated, @Email, @FullName, @Gender, @Faculty, @Country, @AvatarUrl)";
            connection.Execute(query, new { user.UserName, user.Password, user.IsConfirmed, user.Role, user.Birthday, user.DateCreated, user.Email, user.FullName, user.Gender, user.Faculty, user.Country, user.AvatarUrl });

            Server.Transfer("Confirmation.aspx", true);
        }
    }
}