using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.Domain.DTOs
{
    public class CategoryFollowerDTO
    {
        public int ID { get; private set; }
        public int CategoryID { get; private set; }
        public int FollowerID { get; private set; }
        public string FollowerPicture { get; private set; }
        public string FollowerUsername { get; private set; }
        public string FollowerFullname { get; private set; }
    }
}