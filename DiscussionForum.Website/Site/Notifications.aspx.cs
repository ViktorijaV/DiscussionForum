using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace DiscussionForum.Site
{
    public partial class Notifications : System.Web.UI.Page
    {
        private INotificationService _notificationService = new NotificationService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var currentUser = _authenticationService.GetAuthenticatedUser();

                if (currentUser == null)
                    Response.Redirect($"/login?ReturnUrl={Server.UrlEncode(Request.RawUrl)}");

                loadNotifications(currentUser.Id);
            }
        }

        private void loadNotifications(int currentUserId)
        {
            var notificationData = _notificationService.GetUsersNotifications(currentUserId, 5);

            var notifications = notificationData.notifications;
            ViewState["currentUserId"] = currentUserId;
            ViewState["notifizationsSize"] = notificationData.numOfNotifications;
            ViewState["size"] = notificationData.size;

            Notifs.InnerHtml = "";
            foreach (var notification in notifications)
            {
                Notifs.InnerHtml += $"<div class='alert alert-notification'>{notification.Content}<br/><span>{TimePeriod.TimeDifference(notification.DateCreated)}</span></div>";
            }
        }

        private void loadMoreNotifications()
        {
            var currentUserId = int.Parse(ViewState["currentUserId"].ToString());
            var notificationssize = int.Parse(ViewState["notifizationsSize"].ToString());
            var size = int.Parse(ViewState["size"].ToString()) + 10;
            ViewState["size"] = size;

            var notificationData = _notificationService.GetUsersNotifications(currentUserId, size);

            var notifications = notificationData.notifications;
            Notifs.InnerHtml = "";
            foreach (var notification in notifications)
            {
                Notifs.InnerHtml += $"<div class='alert alert-notification'>{notification.Content}<br/><span>{TimePeriod.TimeDifference(notification.DateCreated)}</span></div>";
            }

            if (size > notificationssize)
            {
                loadMore.Visible = false;
                return;
            }
        }

        protected void loadMore_Click(object sender, EventArgs e)
        {
            loadMoreNotifications();
        }
    }
}