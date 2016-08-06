using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForum
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    panelAnonymous.Attributes.Add("style", "display:none");

                else
                    panelAuthorized.Attributes.Add("style", "display:none");
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            //log out user
            Server.Transfer("Home.aspx", false);
        }
    }
}