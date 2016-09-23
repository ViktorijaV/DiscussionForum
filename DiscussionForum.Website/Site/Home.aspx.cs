using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

namespace DiscussionForum.Site
{
    public partial class Home : System.Web.UI.Page
    {
        private ICategoryService _categoryService = new CategoryService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private ITopicService _topicService = new TopicService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCategories();
                loadTopics();
            }
        }

        private void loadTopics()
        {

            var topics = _topicService.GetTopics();
            
            foreach (var topic in topics)
            {
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

        private void loadCategories()
        {
            var categories = _categoryService.LoadCategories();
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