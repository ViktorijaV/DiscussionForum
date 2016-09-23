using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Domain.DTOs;
using System;
using System.Collections.Generic;

namespace DiscussionForum.Domain.Interfaces.Services
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
