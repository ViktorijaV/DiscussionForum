using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.App_Code
{
    public class Comment
    {
        protected Comment() { }

        public Comment(int topicId, int commenterId, string content)
        {
            TopicID = topicId;
            CommenterID = commenterId;
            DateCreated = DateTime.Now;
            Content = content;
            Likes = 0;
            Reported = false;
            Closed = false;
        }

        public int ID { get; private set; }
        public int TopicID { get; private set; }
        public int CommenterID { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Content { get; private set; }
        public int Likes { get; private set; }
        public bool Reported { get; private set; }
        public bool Closed { get; private set; }
    }
}