using System;

namespace DiscussionForum.Domain.DomainModel
{
    public class TopicLike
    {
        public TopicLike(int topicId, int userId)
        {
            TopicID = topicId;
            UserID = userId;
        }
        public int ID { get; private set; }
        public int TopicID { get; private set; }
        public int UserID { get; private set; }
    }
}