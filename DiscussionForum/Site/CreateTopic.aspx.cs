using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using DiscussionForum.AppServices;

namespace DiscussionForum.Site
{
    public partial class CreateTopic : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var authenticationService = new FormsAuthenticationService(HttpContext.Current, connection);
            var user = getCurrentUser(authenticationService);
            if (user == null)
                Response.Redirect("~/login?ReturnUrl=%2fcategory%2fcreate");
            currentUser.ImageUrl = user.PhotoUrl;
            loadCategories(connection);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var authenticationService = new FormsAuthenticationService(HttpContext.Current, connection);
            var currentUser = getCurrentUser(authenticationService);
            var description = Server.HtmlEncode(txtDescription.Text);
            var topic = new App_Code.Topic(currentUser.Id, int.Parse(ddlCategories.SelectedItem.Value), txtTitle.Text, description);

            createTopic(connection, topic);

            //This is not correct!
            Response.RedirectToRoute("TopicRoute", new { id = topic.ID });
        }

        private AuthenticatedUser getCurrentUser(FormsAuthenticationService authenticationService)
        {
            var currentUser = authenticationService.GetAuthenticatedUser();
            return currentUser;
        }

        private void createTopic(SqlConnection connection, App_Code.Topic topic)
        {
            string query = "INSERT INTO Topics (CreatorID, CategoryID, Title, Description, Likes, Replies, Reported, Closed, DateCreated, LastActivity)" +
            "values(@CreatorID, @CategoryID, @Title, @Description, @Likes, @Replies, @Reported, @Closed, @DateCreated, @LastActivity)";
            connection.Execute(query, new { topic.CreatorID, topic.CategoryID, topic.Title, topic.Description, topic.Likes, topic.Replies, topic.Reported, topic.Closed, topic.DateCreated, topic.LastActivity });
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