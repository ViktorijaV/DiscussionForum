using System;
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
    public partial class Register : System.Web.UI.Page
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private IEmailSender _emailSender = new EmailSender();
        private IRecaptchaService _recaptchaService = new RecaptchaService(ConfigurationManager.AppSettings["recatchaSecretKey"]);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
            User user;
            if (male.Checked == true)
                user = DiscussionForum.Domain.DomainModel.User.RegisterUser(txtEmail.Text, txtFullName.Text, txtPassword.Text, txtRepeatPassword.Text, hashedPassword, Gender.Male, Convert.ToDateTime(txtBirthday.Text), ConfigurationManager.AppSettings["profileAvatarUrl"], new UsernameGenerator(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString())));
            else
                user = DiscussionForum.Domain.DomainModel.User.RegisterUser(txtEmail.Text, txtFullName.Text, txtPassword.Text, txtRepeatPassword.Text, hashedPassword, Gender.Female, Convert.ToDateTime(txtBirthday.Text), ConfigurationManager.AppSettings["profileAvatarUrl"], new UsernameGenerator(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString())));


            var errorMessage = _userService.CheckForExistingUser(txtEmail.Text);

            if (errorMessage != "")
            {
                error.InnerText = errorMessage;
                return;
            }

            if (!_recaptchaService.validateRecaptcha(Request["g-recaptcha-response"]))
            {
                error.InnerText = "Not Valid Recaptcha";
                return;
            }

            string message = $@"Please click on the link to confirm your registration: 
                <a href='http://{ConfigurationManager.AppSettings["domainName"]}/confirmation?code={user.ConfirmationCode}'>Link</a>";
            _emailSender.SendEmail("Confirm your registration", message, user.Email);

            _userService.RegisterUser(user);

            Response.Redirect("/confirmation");
        }
            
    }
}