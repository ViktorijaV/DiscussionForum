using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForum.Site
{
    public partial class EditTopic : System.Web.UI.Page
    {
        private ITopicService _topicService = new TopicService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var currentUser = _authenticationService.GetAuthenticatedUser();

            if (currentUser == null)
                redirectToLogin(Request.RawUrl);

            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            loadTopic(topicID, currentUser.Id);
        }

        private void loadTopic(int topicID, int currentUserId)
        {
            var topicDetails = _topicService.GetTopicById(topicID, currentUserId);

            txtEditTitle.Text = topicDetails.Title;
            string description = Server.HtmlDecode(topicDetails.Description).Replace("\"", "'");
            txtEditDesc.InnerHtml = description;
            createdTime.Text = TimePeriod.TimeDifference(topicDetails.DateCreated);
            activeTime.Text = TimePeriod.TimeDifference(topicDetails.LastActivity);

            categoryLink.NavigateUrl = $"/category/{topicDetails.CategoryID}";
            categoryLink.Text = topicDetails.CategoryName;
            categoryLink.BackColor = System.Drawing.ColorTranslator.FromHtml(topicDetails.CategoryColor);

            Followers.InnerText = topicDetails.Followers.ToString();
        }

        private void redirectToLogin(string url)
        {
            Response.Redirect($"~/login?ReturnUrl={Server.UrlEncode(url)}");
        }

        protected void btnEditTopic_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                redirectToLogin(Request.RawUrl);

            var title = txtEditTitle.Text;
            var description = Server.HtmlEncode(txtEditDesc.Value);
            description = txtEditDesc.Value;
            var date = DateTime.Now;

            _topicService.EditTopic(topicID, title, description, date);

            Response.Redirect($"/topic/{topicID}");
        }
    }
}