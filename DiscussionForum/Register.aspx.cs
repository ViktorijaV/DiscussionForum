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
                "<a href=\"localhost:54296/Confirmation.aspx?code=" + user.ConfirmationCode + "\" >Link</a>";
            EMailSender.SendEmail("Confirm your registration", message, user.Email);

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            string query = "INSERT INTO Users (Email, Password, Confirmed, Role, Birthdate, Datecreated, Fullname, Gender, Faculty, Country, Avatar)" +
                "values(@Email, @Password, @Confirmed, @Role, @Birthdate, @DateCreated, @Fullname, @Gender, @Faculty, @Country, @AvatarUrl)";
            connection.Execute(query, new { user.Email, user.Password, user.Confirmed, user.Role, user.Birthdate, user.DateCreated, user.Fullname, user.Gender, user.Faculty, user.Country, user.Avatar });

            Server.Transfer("Confirmation.aspx", true);
        }
    }
}