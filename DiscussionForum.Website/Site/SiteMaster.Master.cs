using DiscussionForum.Services;
using DiscussionForum.Services.Intefraces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using DiscussionForum.Domain.DomainModel;
using EmailService;
using DiscussionForum.Services.Interfaces;

namespace DiscussionForum.Site
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private IEmailSender _emailSender = new EmailSender();
        private IRecaptchaService _recaptchaService = new RecaptchaService(ConfigurationManager.AppSettings["recatchaSecretKey"]);


        protected void Page_Load(object sender, EventArgs e)
        {
            var authenticatedUser = _authenticationService.GetAuthenticatedUser();

            if (authenticatedUser != null)
            {
                linkProfile.HRef = $"~/users/{authenticatedUser.Username}";
                profilePic.ImageUrl = authenticatedUser.PhotoUrl;
                panelAnonymous.Attributes.Add("style", "display:none");
            }
            else
                panelAuthorized.Attributes.Add("style", "display:none");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            _authenticationService.SignOut();
            Response.Redirect("~/home");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var errorMessage = _userService.CheckForExistingUser(friendEmail.Text);

            var authenticatedUser = _authenticationService.GetAuthenticatedUser();


            if (errorMessage == "")
            {
                sendEmail(authenticatedUser.FullName, friendEmail.Text);
            }

            Response.Redirect(Request.RawUrl);
           
        }

        private void sendEmail(string friend, string email)
        {
            string message = $@"Hello, your friend {friend} would like to invite you to check out our computer science forum on the following link: 
                <a href= 'http://{ConfigurationManager.AppSettings["domainName"]}' > Link</a>";
            
                _emailSender.SendEmail("SmartSet", message, email);

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var url = Request.RawUrl;

            if (url != "/")
                Response.Redirect("/login?ReturnUrl=" + Server.UrlEncode(url));

            else Response.Redirect("/login");
        }
    }
}