using Dapper;
using DiscussionForum.App_Code;
using DiscussionForum.DTOs;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace DiscussionForum.Site
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
                loadCategories(sqlConnection);
                loadTopics(sqlConnection);
            }
        }

        private void loadTopics(SqlConnection connection)
        {
            string sql = @"SELECT
                Topics.ID            AS ID,
                Topics.Name          AS Name,
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
                Categories.Name      AS CategoryName,
                Categories.Color     AS CategoryColor
                FROM Topics
                INNER JOIN Users ON Users.ID=Topics.CreatorID
                INNER JOIN Categories ON Categories.ID=Topics.CategoryID";

            var topics = connection.Query<TopicDto>(sql).ToList();
            
            foreach (var topic in topics)
            {
                string pictureUrl = null;
                if (topic.CreatorPicture != "")
                    pictureUrl = topic.CreatorPicture;
                else pictureUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSTFWzSSRSO-HgqfaWagHCvN5Edt6gVVjDGqn7KO_3nUP-gJfCzvgAJkYCy";
                var row = new TableRow();
                var cell = new TableCell();
                cell.Text = $"<span class='table-span'>{topic.Name}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<span class='table-span' style='background-color:{topic.CategoryColor}; color: #ffffff;'>{topic.CategoryName}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<a href='#'><img src='{pictureUrl}' class='table-img'/></a> ";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<span class='table-span'>{topic.Likes.ToString()}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<span class='table-span'>{topic.Replies.ToString()}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<span class='table-span'>{TimePeriod.timeDifference(topic.DateCreated)}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = $"<span class='table-span'>{TimePeriod.timeDifference(topic.LastActivity)}</span>";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = TimePeriod.timeDifferencesInMiliseconds(topic.DateCreated).ToString();
                cell.CssClass = "display-none";
                row.Cells.Add(cell);
                tableTopics.Rows.Add(row);
            }

        }

        private void loadCategories(SqlConnection connection)
        {
            string sql = $"SELECT * FROM Categories";
            var categories = connection.Query<Category>(sql).ToList();
            ListItem item = new ListItem("All Categories", "0");
            item.Attributes.CssStyle.Value = "backgroud-color: #333333";
            ddlCategories.Items.Add(item);

            foreach (var category in categories)
            {
                var li = new ListItem(category.Name, category.ID.ToString());
                li.Attributes.CssStyle.Value += $"backgroud-color: {category.Color}";
                ddlCategories.Items.Add(li);
            }
        }
    }
}