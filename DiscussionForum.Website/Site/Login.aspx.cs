using DiscussionForum.Services;
using DiscussionForum.Services.Intefraces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;

namespace DiscussionForum.Site
{
    public partial class Login : System.Web.UI.Page
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    // This is an unauthorized, authenticated request...
                    Response.Redirect("/accessdenied");
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());

            string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");

            string errorMessage = _userService.CheckUserBeforeLogin(txtEmail.Text, hashedPassword);

            if (errorMessage != "")
            {
                error.InnerText = errorMessage;
                error.Style["display"] = "block";
            }

            else
            {
                var user = _userService.GetUserByEmail(txtEmail.Text);
                _authenticationService.SignIn(user, cbRememberMe.Checked, true);
                var returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl != null)
                    Response.Redirect(returnUrl);
                else Response.Redirect("/home");
            }
        }
    }
}