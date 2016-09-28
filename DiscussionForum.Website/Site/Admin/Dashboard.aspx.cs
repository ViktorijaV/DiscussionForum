using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            var topics = _topicService.GetTopics();
           

            Reported.InnerHtml = "";
            foreach (var top in topics)
            {
                if(top.Reported == true)
                Reported.InnerHtml += $"<div class='alert alert-notification'>{top.Title}<br/><span>{TimePeriod.TimeDifference(top.DateCreated)}</span><asp:LinkButton runat='server' CssClass='btn btn-default pull- right'>&nbsp;&nbsp;Delete comment</asp:LinkButton><asp:LinkButton runat=' server' CssClass=' btn btn-default pull- right'>&nbsp;&nbsp;Delete comment</asp:LinkButton><asp:LinkButton runat='server' CssClass=' btn btn-default pull- right'>&nbsp;&nbsp;Delete report</asp:LinkButton></div>";
            }
        }
    }
}