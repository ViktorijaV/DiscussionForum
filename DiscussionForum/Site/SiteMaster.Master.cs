using DiscussionForum.AppServices;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace DiscussionForum.Site
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
                panelAnonymous.Attributes.Add("style", "display:none");

            else
                panelAuthorized.Attributes.Add("style", "display:none");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            var authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
            authenticationService.SignOut();
            Response.Redirect("Home.aspx");
        }
    }
}