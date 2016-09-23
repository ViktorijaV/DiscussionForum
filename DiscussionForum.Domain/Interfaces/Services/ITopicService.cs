using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Domain.DTOs;
using System;
using System.Collections.Generic;

namespace DiscussionForum.Domain.Interfaces.Services
{
    public interface ITopicService
    {
        void CreateTopic(Topic topic);

        TopicDTO GetTopicById(int topicID, int surrentUserId);

        IList<TopicDTO> GetTopics();

        IList<TopicDTO> GetTopicsByCategory(int categoryID);

        void LikeTopic(TopicLike topicLike);

        void UnlikeTopic(TopicLike topicLike);

        void FollowTopic(TopicFollower topicFollower);

        void UnfollowTopic(TopicFollower topicFollower);
    }
}
