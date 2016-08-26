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
                Topics.Description   AS Description,
                Topics.Likes         AS Likes,
                Topics.Reported      AS Reported,
                Topics.Closed        AS Closed,
                Users.Avatar        AS CreatorPicture,
                Categories.Name     AS CategoryName
                FROM Topics
                INNER JOIN Users ON Users.ID=Topics.CreatorID
                INNER JOIN Categories ON Categories.ID=Topics.CategoryID";
            var topics = connection.Query<TopicDto>(sql).ToList();
            
            foreach (var topic in topics)
            {
                var row = new TableRow();
                var cell = new TableCell();
                cell.Text = topic.Name;
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = topic.CategoryName;
                row.Cells.Add(cell);
                example.Rows.Add(row);
            }

        }

        private void loadCategories(SqlConnection connection)
        {
            string sql = $"SELECT * FROM Categories";
            var categories = connection.Query<Category>(sql).ToList();
            ListItem item = new ListItem("All Categories", "0");
            item.Attributes.CssStyle.Value = "backgroud-color: #333";
            ddlCategories.Items.Add(item);

            foreach (var category in categories)
            {
                var li = new ListItem(category.Name, category.ID.ToString());
                li.Attributes.CssStyle.Value += $"backgroud-color: {category.Color};";
                ddlCategories.Items.Add(li);
            }
        }
    }
}