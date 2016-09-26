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
using EmailService;
using DiscussionForum.Services.Intefraces;
using DiscussionForum.Services.Interfaces;

namespace DiscussionForum.Site
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private IEmailSender _emailSender = new EmailSender();
        private IRecaptchaService _recaptchaService = new RecaptchaService(ConfigurationManager.AppSettings["recatchaSecretKey"]);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string code = (string)Session["code"];
            string email = (string)Session["email"];
            if(code == txtCode.Text)
            {
                //change password
                string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPass.Text, "SHA1");
                User user = _userService.GetUserByEmail(email);
                _userService.ChangePassword(user.ID, hashedPassword);
            }
            else
            {
                error.InnerText = "The code you entered is incorrect. Please try again.";
            }
        }
    }
}