using Dapper;
using DiscussionForum.App_Code;
using DiscussionForum.DTOs;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForum.Site
{
    public partial class CategoryTopic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(Page.RouteData.Values["id"]);
            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            loadCategory(sqlConnection, categoryId);
            loadTopics(sqlConnection, categoryId);
        }

        private void loadCategory(SqlConnection connection, int categoryId)
        {
            string sql = $@"SELECT * FROM Categories
                WHERE Categories.ID = {categoryId}";

            var category = connection.Query<App_Code.Category>(sql).FirstOrDefault();

            categoryName.Text = category.Name;
            categoryName.ForeColor = System.Drawing.ColorTranslator.FromHtml(category.Color);
        }

        private void loadTopics(SqlConnection connection, int categoryId)
        {
            string sql = $@"SELECT
                Topics.ID            AS ID,
                Topics.Title         AS Title,
                Topics.CreatorID     AS CreatorID,
                Topics.CategoryID    AS CategoryID,
                Topics.DateCreated   AS DateCreated,
                Topics.LastActivity  AS LastActivity,
                Topics.Description   AS Description,
                Topics.Likes         AS Likes,
                Topics.Replies       AS Replies,
                Topics.Reported      AS Reported,
                Topics.Closed        AS Closed,
                Users.Avatar         AS CreatorPicture,
                Users.Username       AS CreatorUsername,
                Categories.Name      AS CategoryName,
                Categories.Color     AS CategoryColor
                FROM Topics
                INNER JOIN Users ON Users.ID=Topics.CreatorID
                INNER JOIN Categories ON Categories.ID=Topics.CategoryID
                WHERE Topics.CategoryID = {categoryId}";

            var topics = connection.Query<TopicDto>(sql).ToList();

            foreach (var topic in topics)
            {
                string pictureUrl = null;
                if (topic.CreatorPicture != "")
                    pictureUrl = topic.CreatorPicture;
                else pictureUrl = ConfigurationManager.AppSettings["profileAvatarUrl"];
                var row = new TableRow();
                var cell = new TableCell();
                cell.Text = $"<span class='table-span'>{topic.Title}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<span class='table-span' style='background-color:{topic.CategoryColor}; color: #ffffff;'>{topic.CategoryName}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<a href='/users/{topic.CreatorUsername}'><img src='{topic.CreatorPicture}' class='table-img'/></a> ";
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

    }
}