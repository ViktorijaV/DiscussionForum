using DiscussionForum.Services;
using DiscussionForum.Services.Intefraces;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DiscussionForum.Site
{
    public partial class Confirmation : System.Web.UI.Page
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["code"] != null)
                {
                    var message = $"<h3>{_userService.ConfirmRegistration(Request.QueryString["code"])}</h3>";
                    lblText.Text = message;
                }

                else if (Request.QueryString["message"] == "resetpassword")
                {
                    var message = $"<h3>You password was reset successfully. You can now <a href='/login'>Login</a> with your new password</h3>";
                    lblText.Text = message;
                }

                else if (Request.QueryString["message"] == "sendemail")
                {
                    var message = $"<h3>An email has been send to you. Please check your mailbox for the instructions.</h3>";
                    lblText.Text = message;
                }
            }
        }
    }
}