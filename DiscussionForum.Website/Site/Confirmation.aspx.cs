using DiscussionForum.Domain.Interfaces.Services;
using DiscussionForum.Services;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace DiscussionForum.Site
{
    public partial class Confirmation : System.Web.UI.Page
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["code"] != null)
                {
                    var message = $"<h3>{_userService.ConfirmRegistration(Request.QueryString["code"])}</h3>";
                    lblText.Text = message;
                }
            }
        }
    }
}