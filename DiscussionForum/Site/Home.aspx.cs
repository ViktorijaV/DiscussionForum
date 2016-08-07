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
        List<String> lista;

        protected void Page_Load(object sender, EventArgs e)
        {
            lista = new List<string>();

            lista.Add("Networks");
            lista.Add("OOP");
            lista.Add("SP");
            lista.Add("Shell");
            lista.Add("Discrete mathematics");
            lista.Add("Calculus");
            lista.Add("Web design");
            lista.Add("Web development");

            if (!IsPostBack)
                loadCategories(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        }

        private void loadCategories(SqlConnection connection)
        {
            string sql = $"SELECT * FROM Categories";
            var categories = connection.Query<Category>(sql).ToList();

            foreach (var category in categories)
            {
                //ddlCategories.Items.Add(new ListItem(category.Name, category.ID.ToString()));
            }
        }
    }
}