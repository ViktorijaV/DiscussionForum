using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.DTOs
{
    public class TopicDto
    {
        public int ID { get; set; }
        public string Name { get; private set; }
        public int CreatorID { get; private set; }
        public string CreatorPicture { get; set; }
        public int CategoryID { get; private set; }
        public string CategoryName { get; set; }
        public DateTime DateCreated { get; private set; }
        public string Description { get; private set; }
        public int Likes { get; private set; }
        public bool Reported { get; private set; }
        public bool Closed { get; private set; }
    }
}