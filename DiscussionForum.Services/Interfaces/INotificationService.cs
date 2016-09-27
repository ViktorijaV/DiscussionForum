using DiscussionForum.Domain.DomainModel;
using System.Collections.Generic;

namespace DiscussionForum.Services.Interfaces
{
    public interface INotificationService
    {
        void CreateNotification(Notification notification);

        IList<Notification> GetUsersNotifications(int userId);
    }
}
