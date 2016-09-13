using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.App_Code
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