using Dapper;
using DiscussionForum.App_Code;
using DiscussionForum.AppServices;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DiscussionForum.Site
{
    public partial class CreateTopic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                loadCategories(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            var authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
            var currenUser = authenticationService.GetAuthenticatedUser();

            var topic = new App_Code.Topic(currenUser.Id, int.Parse(ddlCategories.SelectedItem.Value), txtName.Text, txtDescription.Text);

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());

            createTopic(connection, topic);
        }

        private void createTopic(SqlConnection connection, App_Code.Topic topic)
        {
            string query = "INSERT INTO Topics (CreatorID, CategoryID, Name, Description, Likes, Reported, Closed, DateCreated)" +
            "values(@CreatorID, @CategoryID, @Name, @Description, @Likes, @Reported, @Closed, @DateCreated)";
            connection.Execute(query, new { topic.CreatorID, topic.CategoryID, topic.Name, topic.Description, topic.Likes, topic.Reported, topic.Closed, topic.DateCreated });
        }

        private void loadCategories(SqlConnection connection) 
        {
            string sql = $"SELECT * FROM Categories";
            var categories = connection.Query<App_Code.Category>(sql).ToList();

            foreach (var category in categories)
            {
                ddlCategories.Items.Add(new ListItem(category.Name, category.ID.ToString()));
            }
        }
    }
}