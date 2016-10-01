using System;

namespace DiscussionForum.Domain.DomainModel
{
    public class Comment
    {
        protected Comment() { }

        public Comment(int topicId, int commenterId, string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new Exception("Comment text is required!");
            if (content.Length > 5000)
                throw new Exception("Comment text is too long!");
            TopicID = topicId;
            CommenterID = commenterId;
            DateCreated = DateTime.Now;
            Content = content;
            DateEdited = null;
        }

        public int ID { get; private set; }
        public int TopicID { get; private set; }
        public int CommenterID { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateEdited { get; private set; }
        public string Content { get; private set; }
    }
}