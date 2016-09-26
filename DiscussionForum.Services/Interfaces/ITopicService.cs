using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services.DTOs;
using System;
using System.Collections.Generic;

namespace DiscussionForum.Services.Interfaces
{
    public interface ITopicService
    {
        int CreateTopic(Topic topic);

        TopicDTO GetTopicById(int topicID, int surrentUserId);

        IList<TopicDTO> GetTopics();

        IList<TopicDTO> GetTopicsByCategory(int categoryID);

        Topic LikeTopic(TopicLike topicLike);

        void UnlikeTopic(TopicLike topicLike);

        void FollowTopic(TopicFollower topicFollower);

        void UnfollowTopic(TopicFollower topicFollower);

        void EditTopic(int topicID, string title, string description, DateTime date);
    }
}
