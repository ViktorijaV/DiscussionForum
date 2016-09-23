using DiscussionForum.Domain.Interfaces.Services;
using DiscussionForum.Services;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;

namespace DiscussionForum.Site
{
    public partial class Login : System.Web.UI.Page
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()), new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString())));

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());

            string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");

            string errorMessage = _userService.LoginUser(txtEmail.Text, hashedPassword, cbRememberMe.Checked);

            if (errorMessage != "")
                error.InnerText = errorMessage;

            else
            {
                var returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl != null)
                    Response.Redirect(returnUrl);
                else Response.Redirect("/home");
            }
        }
    }
}