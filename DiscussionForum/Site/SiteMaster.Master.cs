using DiscussionForum.AppServices;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace DiscussionForum.Site
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private FormsAuthenticationService _authenticationService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

            var authenticatedUser = _authenticationService.GetAuthenticatedUser();

            if (authenticatedUser != null)
            {
                if (Session["username"] == null)
                    Session["username"] = authenticatedUser.Username;

                linkProfile.HRef = $"~/users/{authenticatedUser.Username}";
                panelAnonymous.Attributes.Add("style", "display:none");
            }
            else
                panelAuthorized.Attributes.Add("style", "display:none");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            _authenticationService.SignOut();
            Session["username"] = null;
            Response.Redirect("~/home");
        }
    }
}