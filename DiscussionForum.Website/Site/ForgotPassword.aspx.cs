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
    public partial class ForgotPassword : System.Web.UI.Page
    {

        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private IEmailSender _emailSender = new EmailSender();
        private IRecaptchaService _recaptchaService = new RecaptchaService(ConfigurationManager.AppSettings["recatchaSecretKey"]);


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            var errorMessage = _userService.CheckForExistingUser(txtEmail.Text);
            string code = Guid.NewGuid().ToString();

            if (errorMessage != "")
            {
                error.InnerText = errorMessage;
            } else
            {
                sendEmail(code, txtEmail.Text);
            }
        }

        private void sendEmail(string confirmationCode, string email)
        {
            string message = $@"Please click on the link to reset your password: 
                <a href='http://{ConfigurationManager.AppSettings["smart-set.azurewebsite.net/profile/ResetPassword.aspx"]}/confirmation?code={confirmationCode}'>Link</a>";
            _emailSender.SendEmail("Change password", message, email);
            
        }
    }
}