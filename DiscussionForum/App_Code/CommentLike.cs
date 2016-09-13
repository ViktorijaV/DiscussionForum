using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.App_Code
{
    public class CommentLike
    {
        public CommentLike(int commentId, int userId)
        {
            CommentID = commentId;
            UserID = userId;
        }
        public int ID { get; private set; }
        public int CommentID { get; private set; }
        public int UserID { get; private set; }
    }
}