using Dapper;
using DiscussionForum.App_Code;
using DiscussionForum.AppServices;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiscussionForum.Site
{
    public partial class Login : System.Web.UI.Page
    {
        private FormsAuthenticationService _authenticationService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());

            string errorMessage = loginUser(connection, txtEmail.Text, txtPassword.Text, cbRememberMe.Checked);

            if (errorMessage != "")
                error.InnerText = errorMessage;

            else {
                var returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl != null)
                    Response.Redirect(returnUrl);
                else Response.Redirect("home");
            }
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

            _authenticationService.SignIn(user, extendExpirationDate, true);

            var authenticatedUser = _authenticationService.GetAuthenticatedUser();
            Session["username"] = authenticatedUser.Username;

            return "";
        }
    }
}