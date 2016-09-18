using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.DTOs
{
    public class CommentDTO
    {
        public int ID { get; private set; }
        public int TopicID { get; private set; }
        public int CommenterID { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Content { get; private set; }
        public string CommenterPicture { get; private set; }
        public string CommenterUsername { get; private set; }
        public int Likes { get; private set; }
        public bool Reported { get; private set; }
        public bool LikedByUser { get; private set; }
        public bool Closed { get; private set; }
    }
}