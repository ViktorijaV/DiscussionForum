using Dapper;
using DiscussionForum.App_Code;
using System;
using System.Collections.Generic;
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
                loadCategories(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
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