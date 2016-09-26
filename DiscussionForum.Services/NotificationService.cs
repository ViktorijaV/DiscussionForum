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
            var sql = $@"INSERT INTO Notifications (UserID, Content, Read, DateCreated)
                         values(@UserID, @Content, @Read, @DateCreated)";
            _connection.Execute(sql, new { notification.UserID, notification.Content, notification.Read, notification.DateCreated });
        }

        public void ReadNotification(int ID)
        {
            var read = true;
            var sql = $@"UPDATE Notifications
                         SET Notifications.Read = @Read
                         WHERE Notifications.ID = @ID";
            _connection.Execute(sql, new { read, ID });
        }

        public IList<Notification> GetAllUsersNotifications(int userId)
        {
            var sql = $@"SELECT
                         Notifications.ID              AS ID,
                         Notifications.UserID          AS UserID,
                         Notifications.Content         AS Content,
                         Notifications.DateCreated     AS DateCreated,
                         Notifications.Read            AS Read
                         FROM Notifications
                         WHERE Notifications.UserID = {userId}";

            var notifications = _connection.Query<Notification>(sql).ToList();

            return notifications;
        }

        public IList<Notification> GetUnreadUsersNotifications(int userId)
        {
            var sql = $@"SELECT
                         Notifications.ID              AS ID,
                         Notifications.UserID          AS UserID,
                         Notifications.Content         AS Content,
                         Notifications.DateCreated     AS DateCreated,
                         Notifications.Read            AS Read
                         FROM Notifications
                         WHERE Notifications.UserID = {userId} AND Notifications.Read = 'true'";

            var notifications = _connection.Query<Notification>(sql).ToList();

            return notifications;
        }
    }
}
