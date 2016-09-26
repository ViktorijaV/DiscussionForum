using DiscussionForum.Domain.DomainModel;
using System.Collections.Generic;

namespace DiscussionForum.Services.Interfaces
{
    public interface INotificationService
    {
        void CreateNotification(Notification notification);

        void ReadNotification(int ID);

        IList<Notification> GetAllUsersNotifications(int userId);

        IList<Notification> GetUnreadUsersNotifications(int userId);
    }
}
