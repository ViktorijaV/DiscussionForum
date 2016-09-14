using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.App_Code
{
    public class Topic
    {

        public Topic(int creatorId, int categoryId, string title, string description)
        {
            CreatorID = creatorId;
            CategoryID = categoryId;
            Title = title;
            Description = description;
            DateCreated = DateTime.Now;
            LastActivity = DateCreated;
            Reported = false;
            Closed = false;
        }

        public int ID { get; private set; }
        public int CreatorID { get; private set; }
        public int CategoryID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastActivity { get; private set; }
        public bool Reported { get; private set; }
        public bool Closed { get; private set; }
    }
}