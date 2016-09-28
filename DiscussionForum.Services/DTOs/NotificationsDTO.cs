using DiscussionForum.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionForum.Services.DTOs
{
    public class NotificationsDTO
    {
        public IList<Notification> notifications { get; set; }
        public int numOfNotifications { get; set; }
        public int size { get; set; }
    }
}
