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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            var errorMessage = _userService.CheckForExistingUser(email);
            if (errorMessage == "")
            {
                error.InnerText = "User with that email address doesn't have a profile on SmartSet.";
                return;
            }
            string code = Guid.NewGuid().ToString();
            _userService.ChangeUserConfirmationCode(email, code);
            sendEmail(code, email);
            Response.Redirect("/confirmation?message=sendemail");
        }

        private void sendEmail(string confirmationCode, string email)
        {
            string message = $@"Please click on the link to reset your password: 
                <a href='http://{ConfigurationManager.AppSettings["domainName"]}/resetpassword'>Link</a>. 
                The code for reseting the password is {confirmationCode}.";
            _emailSender.SendEmail("Change password", message, email);
        }
    }
}