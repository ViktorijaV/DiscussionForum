using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.Domain.DTOs
{
    public class TopicDTO
    {
        public int ID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int CreatorID { get; private set; }
        public string CreatorPicture { get; private set; }
        public string CreatorUsername { get; private set; }
        public int CategoryID { get; private set; }
        public string CategoryName { get; private set; }
        public string CategoryColor { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastActivity { get; private set; }
        public int Likes { get; private set; }
        public int Replies { get; private set; }
        public int Followers { get; private set; }
        public bool CurrentUserFollows { get; private set; }
        public bool CurrentUserLikes { get; private set; }
        public bool Reported { get; private set; }
        public bool Closed { get; private set; }
    }
}