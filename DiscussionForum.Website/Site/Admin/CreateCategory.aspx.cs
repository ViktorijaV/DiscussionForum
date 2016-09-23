using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace DiscussionForum.Site.Admin
{
    public partial class CreateCategory : System.Web.UI.Page
    {
        private ICategoryService _categoryService = new CategoryService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            var category = new DiscussionForum.Domain.DomainModel.Category(txtName.Text, txtColor.Text);
            _categoryService.CreateCategory(category);
        }
    }
}