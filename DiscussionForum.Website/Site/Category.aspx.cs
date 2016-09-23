using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DiscussionForum.Site
{
    public partial class CategoryTopic : System.Web.UI.Page
    {
        private ICategoryService _categoryService = new CategoryService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private ITopicService _topicService = new TopicService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            int categoryID = Convert.ToInt32(Page.RouteData.Values["id"]);
           var currentUser = _authenticationService.GetAuthenticatedUser();
            loadCategory(categoryID);
            loadTopics(categoryID);
            loadFollowers(categoryID, currentUser);
        }

        private void loadCategory(int categoryID)
        {
            var category = _categoryService.GetCategoryById(categoryID); 

            categoryName.Text = category.Name;
            categoryName.ForeColor = System.Drawing.ColorTranslator.FromHtml(category.Color);
        }

        private void loadFollowers(int categoryID, AuthenticatedUser currentUser)
        {
            btnUnfollow.Style.Add("display", "none");

            var followers = _categoryService.GetFollowers(categoryID);

            listFollowers.Controls.Clear();
            var heading = new HtmlGenericControl("li");
            heading.Attributes.Add("class", "list-group-item list-group-item-heading");
            heading.InnerText = "FOLLOWERS";
            listFollowers.Controls.Add(heading);

            foreach (var follower in followers)
            {
                if (currentUser != null && follower.FollowerID == currentUser.Id)
                {
                    btnFollow.Style.Add("display", "none");
                    btnUnfollow.Style.Add("display", "inline-block");
                }
                var li = new HtmlGenericControl("li");
                li.Attributes.Add("class", "list-group-item");
                li.InnerHtml = $"<a href='/users/{follower.FollowerUsername}'><img src='{follower.FollowerPicture}' class='img-rounded pull-left list-group-img'/>{follower.FollowerFullname}</a>";
                listFollowers.Controls.Add(li);
            }

            if (followers.Count == 0)
            {
                var li = new HtmlGenericControl("li");
                li.Attributes.Add("class", "list-group-item");
                li.InnerText = "No followers";
                listFollowers.Controls.Add(li);
            }

        }

        private void loadTopics(int categoryID)
        {
            var topics = _topicService.GetTopicsByCategory(categoryID);

            foreach (var topic in topics)
            {
                string pictureUrl = null;
                if (topic.CreatorPicture != "")
                    pictureUrl = topic.CreatorPicture;
                else pictureUrl = ConfigurationManager.AppSettings["profileAvatarUrl"];
                var row = new TableRow();
                var cell = new TableCell();
                cell.Text = $"<a href='/topic/{topic.ID}'><span class='table-span'>{topic.Title}</span></a>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<a href='/category/{topic.CategoryID}'><span class='table-span' style='background-color:{topic.CategoryColor}; color: #ffffff;'>{topic.CategoryName}</span></a>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<a href='/users/{topic.CreatorUsername}'><img src='{topic.CreatorPicture}' class='img-rounded table-img'/></a> ";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<span class='table-span'>{topic.Likes.ToString()}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<span class='table-span'>{topic.Replies.ToString()}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<span class='table-span'>{TimePeriod.TimeDifference(topic.DateCreated)}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<span class='table-span'>{TimePeriod.TimeDifference(topic.LastActivity)}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = TimePeriod.TimeDifferencesInMiliseconds(topic.DateCreated).ToString();
                cell.CssClass = "display-none";
                row.Cells.Add(cell);
                tableTopics.Rows.Add(row);
            }

        }

        protected void btnFollow_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int categoryID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                Response.Redirect($"~/login?ReturnUrl=%2fcategory%2f{categoryID}");

            var categoryFollower = new CategoryFollower(categoryID, currentUser.Id);

            _categoryService.FollowCategory(categoryFollower);

            btnFollow.Style.Add("display", "none");
            btnUnfollow.Style.Add("display", "inline-block");

            loadFollowers(categoryID, currentUser);
        }

        protected void btnUnfollow_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int categoryID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                Response.Redirect($"~/login?ReturnUrl=%2fcategory%2f{categoryID}");

            var categoryFollower = new CategoryFollower(categoryID, currentUser.Id);

            _categoryService.UnfollowCategory(categoryFollower);

            btnUnfollow.Style.Add("display", "none");
            btnFollow.Style.Add("display", "inline-block");

            loadFollowers(categoryID, currentUser);
        }
    }
}