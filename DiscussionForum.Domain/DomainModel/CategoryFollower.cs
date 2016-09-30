using System;

namespace DiscussionForum.Domain.DomainModel
{
    public class CategoryFollower
    {
        public CategoryFollower(int categoryId, int followerId)
        {
            CategoryID = categoryId;
            FollowerID = followerId;
        }
        public int ID { get; private set; }
        public int CategoryID { get; private set; }
        public int FollowerID { get; private set; }
    }
}