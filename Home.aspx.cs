using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            pnlHeader.BackColor = Color.IndianRed;
            pnlFooter.BackColor = Color.IndianRed;
            pnlContent.BackColor = Color.LightYellow;
        }
    }
}