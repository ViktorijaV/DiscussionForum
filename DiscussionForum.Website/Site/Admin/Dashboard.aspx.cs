using System;
using System.Web;
using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using EmailService;
using DiscussionForum.Services.Intefraces;

namespace DiscussionForum.Site.Admin
{
    public partial class Dashboard : System.Web.UI.Page

    {
        private ITopicService _topicService = new TopicService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private ICommentService _commentService = new CommentService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private IEmailSender _emailSender = new EmailSender();
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var authenticatedUser = _authenticationService.GetAuthenticatedUser();
                if (authenticatedUser == null)
                    redirectToLogin(Request.RawUrl);

                if (authenticatedUser.Role != "Admin")
                    Response.Redirect("/accessdenied");

                loadReportedTopics();
                loadReportedComments();
            }
        }

        private void redirectToLogin(string url)
        {
            Response.Redirect($"~/login?ReturnUrl={Server.UrlEncode(url)}");
        }

        private void loadReportedTopics()
        {
            var reports = _topicService.GetTopicsReports();


            ReportedTopics.InnerHtml = "";
            foreach (var report in reports)
            {
                ReportedTopics.InnerHtml += $@"<div class='alert alert-notification repDiv'>
                <button class='btn btn-icon pull-right faa-parent animated-hover tool expand deleteTopicReport' data-title='Delete this report'><i class='fa fa-times faa-flash'></i></button>
                <input type='hidden' class='reportID' value='{report.ID}'/>
                <input type='hidden' class='topicID' value='{report.TopicID}'/>
                <a href='users/{report.ReporterUsername}'>{report.ReporterUsername}</a> reported the topic <a href='/topic/{report.TopicID}'>{report.TopicTitle}</a> with the reason: <strong>{report.Reason}</strong>
                <br/><br/><span>{TimePeriod.TimeDifference(report.DateCreated)}</span>
                <button class='btn btn-default deleteTopic'><i class='fa fa-trash'></i>&nbsp;Delete topic</button>
                </div>";
            }
        }

        private void loadReportedComments()
        {
            var reports = _commentService.GetCommentReports();


            ReportedComments.InnerHtml = "";
            foreach (var report in reports)
            {
                var content = Server.HtmlDecode(report.CommentContent);
                content = content.Substring(0, Math.Min(content.Length, 10));
                ReportedComments.InnerHtml += $@"<div class='alert alert-notification repDiv'>
                <button class='btn btn-icon pull-right faa-parent animated-hover tool expand deleteCommentReport' data-title='Delete this report'><i class='fa fa-times faa-flash'></i></button>
                <input type='hidden' class='reportCommentID' value='{report.ID}'/>
                <input type='hidden' class='commentID' value='{report.CommentID}'/>
                <a href='/users/{report.ReporterUsername}'>{report.ReporterUsername}</a> reported the comment from <strong>user with id {report.CommenterID}</strong> commented {TimePeriod.TimeDifference(report.CommentDateCreated)}
                on the topic <a href='/topic/{report.TopicID}'>{report.TopicTitle}</a> with the reason: <strong>{report.Reason}</strong>
                <br/><br/><span>{TimePeriod.TimeDifference(report.DateCreated)}</span>
                <button class='btn btn-default deleteComment'><i class='fa fa-trash'></i>&nbsp;Delete comment</button>
                </div>";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            User user = _userService.GetUserByUsername(txtUsername.Text);

            if (user == null)
            {
                error.InnerText = "The username is not valid, please try again.";
            }
            else
            {
                _userService.BlockUser(txtUsername.Text);
                string email = user.Email;
                sendEmail(email, txtUsername.Text);
                error.InnerText = "The username is not valid, please try again.";
                error.Style.Add("display", "none");
            }
        }

        private void sendEmail(string email, string username)
        {
            string message = $@"{username}, you have been blocked from SmartSet. You can follow the following link and read the terms and conditions of our web site. You will no longer be able to login with your account, or create a new account with your current email. 
               <a href='http://{ConfigurationManager.AppSettings["domainName"]}/termsandconditions'>link</a>.";
            _emailSender.SendEmail("Blocked user", message, email);
        }

        protected void btnDeleteTopicReport_Click(object sender, EventArgs e)
        {
            var reportId = int.Parse(topicReportId.Value);

            _topicService.DeleteTopicReport(reportId);

            loadReportedTopics();

            
        }

        protected void btnDeleteCommentReport_Click(object sender, EventArgs e)
        {
            var reportId = int.Parse(commentReportId.Value);

            _commentService.DeleteCommentReport(reportId);

            loadReportedComments();
        }

        protected void btnDeleteTopic_Click(object sender, EventArgs e)
        {
            var topicId = int.Parse(topicID.Value);

            _topicService.DeleteTopic(topicId);

            loadReportedTopics();
        }

        protected void btnDeleteComment_Click(object sender, EventArgs e)
        {
            var commentId = int.Parse(commentID.Value);

            _commentService.DeleteComment(commentId);

            loadReportedComments();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int code = 0;
            bool res = int.TryParse(txtTopicCode.Text, out code);

            if(res == false)
            {
                error.InnerText = "Invalid code.";
            }
            else
            {
                _topicService.CloseTopic(code);
                error.InnerText = "";
                error.Style.Add("display", "none");
            }
        }
    }
}