using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.App_Code
{
    public class Topic
    {
        protected Topic() { }

        public Topic(int creatorId, int categoryId, string name, string description)
        {
            CreatorID = creatorId;
            CategoryID = categoryId;
            DateCreated = DateTime.Now;
            Name = name;
            Description = description;
            Likes = 0;
            Reported = false;
            Closed = false;
        }

        public int ID { get; private set; }
        public int CreatorID { get; private set; }
        public int CategoryID { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Likes { get; private set; }
        public bool Reported { get; private set; }
        public bool Closed { get; private set; }
    }
}