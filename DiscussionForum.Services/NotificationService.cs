using DiscussionForum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscussionForum.Domain.DomainModel;
using System.Data;
using Dapper;

namespace DiscussionForum.Services
{
    public class NotificationService : INotificationService
    {
        private IDbConnection _connection { get; set; }

        public NotificationService(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateNotification(Notification notification)
        {
            var sql = $@"INSERT INTO Notifications (UserID, Content, DateCreated)
                         values(@UserID, @Content, @DateCreated)";
            _connection.Execute(sql, new { notification.UserID, notification.Content, notification.DateCreated });
        }

        public IList<Notification> GetUsersNotifications(int userId)
        {
            var sql = $@"SELECT *
                         FROM Notifications
                         WHERE Notifications.UserID = {userId}
                         ORDER BY Notifications.DateCreated DESC";

            var notifications = _connection.Query<Notification>(sql).ToList();

            return notifications;
        }
    }
}
