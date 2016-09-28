using System;
using System.Web;
using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using EmailService;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using DiscussionForum.Services.Intefraces;

namespace DiscussionForum.Site.Admin
{
    public partial class Dashboard : System.Web.UI.Page

    {
        private ITopicService _topicService = new TopicService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private IEmailSender _emailSender = new EmailSender();
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {

            loadReported();

            if (!IsPostBack)
            {
                var authenticatedUser = _authenticationService.GetAuthenticatedUser();
                if (authenticatedUser == null)
                    redirectToLogin(Request.RawUrl);

                if (authenticatedUser.Role != "Admin")
                    Response.Redirect("/accessdenied");

              
            }
        }

        private void redirectToLogin(string url)
        {
            Response.Redirect($"~/login?ReturnUrl={Server.UrlEncode(url)}");
        }

        private void loadReported()
        {
            var reports = _topicService.GetTopicsReports();


            Reported.InnerHtml = "";
            foreach (var report in reports)
            {
                Reported.InnerHtml += $"<div class='alert alert-notification repDiv'>{report.ID}<br/><span>{TimePeriod.TimeDifference(report.DateCreated)}</span><button class='btn btn-default pull- right repButton'>Delete comment</button><button class='btn btn-default pull- right repButton'>Delete report</button></div>";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            User user = _userService.GetUserByUsername(txtUsername.Text);

            if(user == null)
            {
                error.InnerText = "The username is not valid, please try again.";
            } else
            {
                _userService.BlockUser(txtUsername.Text);
                string email = user.Email;
                sendEmail(email, txtUsername.Text);
            }
        }

        private void sendEmail(string email, string username)
        {
            string message = $@"{username}, you have been blocked from SmartSet. You can follow the following link and read the terms and conditions of our web site. You will no longer be able to login with your account, or create a new account with your current email. 
               <a href='http://{ConfigurationManager.AppSettings["domainName"]}/termsandconditions'>Link</a>.";
            _emailSender.SendEmail("Blocked user", message, email);
        }
    }
}