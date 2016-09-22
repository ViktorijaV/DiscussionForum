using Dapper;
using DiscussionForum.AppServices;
using DiscussionForum.Domain.DomainModel;
using DiscussionForum.DTOs;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DiscussionForum.Site
{
    public partial class CategoryTopic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int categoryID = Convert.ToInt32(Page.RouteData.Values["id"]);
            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var currentUser = new FormsAuthenticationService(HttpContext.Current, sqlConnection).GetAuthenticatedUser();
            loadCategory(sqlConnection, categoryID);
            loadTopics(sqlConnection, categoryID);
            loadFollowers(sqlConnection, categoryID, currentUser);
        }

        private void loadCategory(SqlConnection connection, int categoryID)
        {
            string sql = $@"SELECT * FROM Categories
                WHERE Categories.ID = {categoryID}";

            var category = connection.Query<DiscussionForum.Domain.DomainModel.Category>(sql).FirstOrDefault();

            categoryName.Text = category.Name;
            categoryName.ForeColor = System.Drawing.ColorTranslator.FromHtml(category.Color);
        }

        private void loadFollowers(SqlConnection connection, int categoryID, AuthenticatedUser currentUser)
        {
            btnUnfollow.Style.Add("display", "none");

            string sql = $@"SELECT
                CategoryFollowers.FollowerID    AS FollowerID,
                Users.Avatar                    AS FollowerPicture,
                Users.Username                  AS FollowerUsername,
                Users.Fullname                  AS FollowerFullname
                FROM CategoryFollowers
                INNER JOIN Users ON Users.ID=CategoryFollowers.FollowerID
                WHERE CategoryFollowers.CategoryID = {categoryID}";

            var followers = connection.Query<CategoryFollowerDTO>(sql).ToList();
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

        private void loadTopics(SqlConnection connection, int categoryID)
        {
            string sql = $@"SELECT
                Topics.ID            AS ID,
                Topics.Title         AS Title,
                Topics.CreatorID     AS CreatorID,
                Topics.CategoryID    AS CategoryID,
                Topics.DateCreated   AS DateCreated,
                Topics.LastActivity  AS LastActivity,
                Topics.Description   AS Description,
                (SELECT COUNT(*)
                 FROM TopicLikes
                 WHERE TopicLikes.TopicID = Topics.ID)
                                     AS Likes,
                (SELECT COUNT(*)
                       FROM Comments
                       WHERE Comments.TopicID = Topics.ID)
                                     AS Replies,
                Topics.Reported      AS Reported,
                Topics.Closed        AS Closed,
                Users.Avatar         AS CreatorPicture,
                Users.Username       AS CreatorUsername,
                Categories.Name      AS CategoryName,
                Categories.Color     AS CategoryColor
                FROM Topics
                INNER JOIN Users ON Users.ID=Topics.CreatorID
                INNER JOIN Categories ON Categories.ID=Topics.CategoryID
                WHERE Topics.CategoryID = {categoryID}
                ORDER BY Topics.LastActivity DESC";

            var topics = connection.Query<TopicDTO>(sql).ToList();

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
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var currentUser = new FormsAuthenticationService(HttpContext.Current, connection).GetAuthenticatedUser();
            int categoryID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                Response.Redirect($"~/login?ReturnUrl=%2fcategory%2f{categoryID}");

            var categoryFollower = new CategoryFollower(categoryID, currentUser.Id);

            string query = @"INSERT INTO CategoryFollowers (CategoryID, FollowerID)
                             values(@CategoryID, @FollowerID)";
            connection.Execute(query, new { categoryFollower.CategoryID, categoryFollower.FollowerID });

            btnFollow.Style.Add("display", "none");
            btnUnfollow.Style.Add("display", "inline-block");

            loadFollowers(connection, categoryID, currentUser);
        }

        protected void btnUnfollow_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var currentUser = new FormsAuthenticationService(HttpContext.Current, connection).GetAuthenticatedUser();
            int categoryID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                Response.Redirect($"~/login?ReturnUrl=%2fcategory%2f{categoryID}");

            var categoryFollower = new CategoryFollower(categoryID, currentUser.Id);

            string query = @"DELETE FROM CategoryFollowers 
                             WHERE CategoryID = @CategoryID 
                             AND FollowerID = @FollowerID";
            connection.Execute(query, new { categoryFollower.CategoryID, categoryFollower.FollowerID });

            btnUnfollow.Style.Add("display", "none");
            btnFollow.Style.Add("display", "inline-block");

            loadFollowers(connection, categoryID, currentUser);
        }
    }
}