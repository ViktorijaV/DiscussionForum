using Dapper;
using DiscussionForum.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForum.Site.Admin
{
    public partial class CreateCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            var category = new App_Code.Category(txtName.Text);

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());

            createCategory(connection, category);
        }

        private void createCategory(SqlConnection connection, App_Code.Category category)
        {
            string query = "INSERT INTO Categories (Name)" +
            "values(@Name)";
            connection.Execute(query, new { category.Name });
        }
    }
}