using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForum.Site
{
    public partial class Notifications : System.Web.UI.Page
    {
        private INotificationService _notificationService = new NotificationService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();

            if (currentUser == null)
                Response.Redirect($"login?ReturnUrl={Server.UrlEncode(Request.RawUrl)}");

            loadNotifications(currentUser.Id);
        }

        private void loadNotifications(int currentUserId)
        {
            var notifications = _notificationService.GetUsersNotifications(currentUserId);

            Notifs.InnerHtml = "";
            foreach (var notification in notifications)
            {
                Notifs.InnerHtml += $"<div class='alert alert-notification'>{notification.Content}<br/><span>{TimePeriod.TimeDifference(notification.DateCreated)}</span></div>";
            }
        }
    }
}