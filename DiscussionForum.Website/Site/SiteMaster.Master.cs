using DiscussionForum.Services;
using DiscussionForum.Services.Intefraces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace DiscussionForum.Site
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            var authenticatedUser = _authenticationService.GetAuthenticatedUser();

            if (authenticatedUser != null)
            {
                linkProfile.HRef = $"~/users/{authenticatedUser.Username}";
                profilePic.ImageUrl = authenticatedUser.PhotoUrl;
                panelAnonymous.Attributes.Add("style", "display:none");
            }
            else
                panelAuthorized.Attributes.Add("style", "display:none");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            _authenticationService.SignOut();
            Response.Redirect("~/home");
        }
    }
}