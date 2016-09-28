using System;
using System.Web;
using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using EmailService;

namespace DiscussionForum.Site.Admin
{
    public partial class Dashboard : System.Web.UI.Page

    {
        private ITopicService _topicService = new TopicService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private IEmailSender _emailSender = new EmailSender();

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

        }
    }
}