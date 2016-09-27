using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using DiscussionForum.Services;
using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services.Intefraces;

namespace DiscussionForum.Site
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var code = txtCode.Text;
            var email = txtEmail.Text;
            var pass = txtPass.Text;
            var confirmpass = txtCofirm.Text;
            var user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                error.InnerText = "User with that email address does not exists. Please check the email you have entered.";
                return;
            }
            if(pass != confirmpass)
            {
                error.InnerHtml = "Passwords doesn't match. Please try again.";
                return;
            }

            if(user.ConfirmationCode != code)
            {
                error.InnerText = "The code you entered is incorrect. Please try again.";
                return;
            }

            var hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "SHA1");
            _userService.ChangePassword(user.ID, hashedPassword);
            Response.Redirect("/confirmation?message=resetpassword");
        }
    }
}