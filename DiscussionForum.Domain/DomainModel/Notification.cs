using System;

namespace DiscussionForum.Domain.DomainModel
{
    public class Notification
    {
        public Notification() { }

        public Notification(int userId, string content, DateTime dateCreated)
        {
            UserID = userId;
            Content = content;
            DateCreated = dateCreated;
        }
        public int ID { get; private set; }
        public int UserID { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; }
    }
}
