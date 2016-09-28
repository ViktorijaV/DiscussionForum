using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using System.Configuration;
using System.Data.SqlClient;

namespace DiscussionForum.Site.Admin
{
    public partial class Dashboard : System.Web.UI.Page

    {
        private ITopicService _topicService = new TopicService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void loadReported()
        {
            var topics = _topicService.GetTopics();
           

            Reported.InnerHtml = "";
            foreach (var top in topics)
            {
                if(top.Reported == true)
                Reported.InnerHtml += $"<div class='alert alert-notification'>{top.Title}<br/><span>{TimePeriod.TimeDifference(top.DateCreated)}</span><asp:LinkButton runat='server' CssClass='btn btn-default pull- right'>&nbsp;&nbsp;Delete comment</asp:LinkButton><asp:LinkButton runat=' server' CssClass=' btn btn-default pull- right'>&nbsp;&nbsp;Delete comment</asp:LinkButton><asp:LinkButton runat='server' CssClass=' btn btn-default pull- right'>&nbsp;&nbsp;Delete report</asp:LinkButton></div>";
            }
        }
    }
}