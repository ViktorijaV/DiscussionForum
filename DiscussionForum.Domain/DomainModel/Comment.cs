using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.Domain.DomainModel
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
            Reported = false;
            Closed = false;
            DateEdited = null;
        }

        public int ID { get; private set; }
        public int TopicID { get; private set; }
        public int CommenterID { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateEdited { get; private set; }
        public string Content { get; private set; }
        public bool Reported { get; private set; }
        public bool Closed { get; private set; }
    }
}