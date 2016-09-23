using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services.DTOs;
using System;
using System.Collections.Generic;

namespace DiscussionForum.Services.Interfaces
{
    public interface ICommentService
    {
        void EditComment(int topicID, string Id, string content, DateTime date);

        void LikeComment(int Id, int commentId);

        void UnlikeComment(int Id, int commentId);

        void CreateComment(Comment comment);

        IList<CommentDTO> GetComments(int topicID, int currentUserId);
    }
}
