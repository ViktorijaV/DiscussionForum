using DiscussionForum.Services.Interfaces;
using System.Linq;
using DiscussionForum.Domain.DomainModel;
using System.Data;
using Dapper;
using DiscussionForum.Services.DTOs;

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

        public NotificationsDTO GetUsersNotifications(int userId, int size)
        {
            var sqlcount = $@"SELECT COUNT(*) FROM Notifications
                              WHERE Notifications.UserID = {userId}";
            var notifssize = _connection.Query<int>(sqlcount).FirstOrDefault();
            var sql = $@"SELECT TOP {size} *
                      FROM Notifications
                      WHERE Notifications.UserID = {userId}
                      ORDER BY Notifications.DateCreated DESC";

            var notifs = _connection.Query<Notification>(sql).ToList();

            return new NotificationsDTO { notifications = notifs, numOfNotifications = notifssize, size = size };
        }
    }
}
