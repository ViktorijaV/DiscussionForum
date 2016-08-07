using Dapper;
using DiscussionForum.App_Code;
using DiscussionForum.AppServices;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiscussionForum
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());

            string errorMessage = loginUser(connection, txtEmail.Text, txtPassword.Text, cbRememberMe.Checked);

            if (errorMessage != "")
                error.InnerText = errorMessage;

            //TODO: implement returlurl 
            else Response.Redirect("Site/Home.aspx");
        }

        private string loginUser(SqlConnection connection, string email, string password, bool extendExpirationDate)
        {
            string sql = $"SELECT * FROM Users WHERE Email='{email}'";
            var user = connection.Query<User>(sql).FirstOrDefault();

            if (user == null)
                return "User with that email does not exists! Please register.";

            if (user.Confirmed == false)
                return "Your account is not confirmed! Please confirm your account.";

            if (user.Password != password)
                return "Wrong password!";

            var authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
            authenticationService.SignIn(user, extendExpirationDate, true);
            return "";
        }
    }
}