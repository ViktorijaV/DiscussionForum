using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services.DTOs;
using System.Collections.Generic;

namespace DiscussionForum.Services.Interfaces
{
    public interface INotificationService
    {
        void CreateNotification(Notification notification);

        NotificationsDTO GetUsersNotifications(int userId, int size);
    }
}
