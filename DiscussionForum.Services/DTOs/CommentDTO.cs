using System;

namespace DiscussionForum.Services.DTOs
{
    public class CommentDTO
    {
        public int ID { get; private set; }
        public int TopicID { get; private set; }
        public int CommenterID { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateEdited { get; private set; }
        public string Content { get; private set; }
        public string CommenterPicture { get; private set; }
        public string CommenterUsername { get; private set; }
        public int Likes { get; private set; }
        public bool LikedByUser { get; private set; }
    }
}