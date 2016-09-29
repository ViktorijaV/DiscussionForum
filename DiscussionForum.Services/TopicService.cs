using Dapper;
using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services.DTOs;
using DiscussionForum.Services.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;

namespace DiscussionForum.Services
{
    public class TopicService : ITopicService
    {
        private IDbConnection _connection { get; set; }

        public TopicService(IDbConnection connection)
        {
            _connection = connection;
        }

        public int CreateTopic(Topic topic)
        {

            string query = @"INSERT INTO Topics (CreatorID, CategoryID, Title, Description, Closed, DateCreated, DateEdited, LastActivity)
                                values(@CreatorID, @CategoryID, @Title, @Description, @Closed, @DateCreated, @DateEdited, @LastActivity)
                                SELECT CAST(SCOPE_IDENTITY() as int)";
            int id = 0;
            try
            {
                id = _connection.Query<int>(query, new { topic.CreatorID, topic.CategoryID, topic.Title, topic.Description, topic.Closed, topic.DateCreated, topic.DateEdited, topic.LastActivity }).FirstOrDefault(); 
            } catch(Exception e)
            {
                return -1;
            }

            return id;
        }

        public TopicDTO GetTopicById(int topicID, int Id)
        {

            var sqlQueryTopic = $@"SELECT
                                   Topics.ID                AS ID,
                                   Topics.Title             AS Title,
                                   Topics.CreatorID         AS CreatorID,
                                   Topics.CategoryID        AS CategoryID,
                                   Topics.DateCreated       AS DateCreated,
                                   Topics.DateEdited        AS DateEdited,
                                   Topics.LastActivity      AS LastActivity,
                                   Topics.Description       AS Description,
                                   Topics.Closed            AS Closed,
                                   Users.Avatar             AS CreatorPicture,
                                   Users.Username           AS CreatorUsername,
                                   Categories.Name          AS CategoryName,
                                   Categories.Color         AS CategoryColor,
                                   (SELECT COUNT(*)
                                          FROM TopicFollowers
                                          WHERE TopicFollowers.TopicID = {topicID})
                                                            AS Followers,
                                   (SELECT COUNT(*)
                                    FROM TopicLikes
                                    WHERE TopicLikes.TopicID = {topicID})
                                                            AS Likes,
                                   (SELECT COUNT(*)
                                          FROM Comments
                                          WHERE Comments.TopicID = {topicID})
                                                            AS Replies,
                                   (SELECT CAST(COUNT(1) AS BIT)
                                           FROM TopicFollowers
                                           WHERE TopicFollowers.TopicID = {topicID} AND TopicFollowers.FollowerID = {Id})
                                                             AS CurrentUserFollows,
                                   (SELECT CAST(COUNT(1) AS BIT)
                                            FROM TopicLikes
                                            WHERE TopicLikes.TopicID = {topicID} AND TopicLikes.UserID = {Id})
                                                             AS CurrentUserLikes
                                   FROM Topics
                                   INNER JOIN Users ON Users.ID=Topics.CreatorID
                                   INNER JOIN Categories ON Categories.ID=Topics.CategoryID
                                   WHERE Topics.ID = {topicID}";

            var topic = _connection.Query<TopicDTO>(sqlQueryTopic).FirstOrDefault();
            return topic;
        }

        public IList<TopicDTO> GetTopics()
        {

            string sql = @"SELECT
                Topics.ID            AS ID,
                Topics.Title         AS Title,
                Topics.CreatorID     AS CreatorID,
                Topics.CategoryID    AS CategoryID,
                Topics.DateCreated   AS DateCreated,
                Topics.DateEdited    AS DateEdited,
                Topics.LastActivity  AS LastActivity,
                Topics.Description   AS Description,
                (SELECT COUNT(*)
                 FROM TopicLikes
                 WHERE TopicLikes.TopicID = Topics.ID)
                                     AS Likes,
                (SELECT COUNT(*)
                       FROM Comments
                       WHERE Comments.TopicID = Topics.ID)
                                     AS Replies,
                Topics.Closed        AS Closed,
                Users.Avatar         AS CreatorPicture,
                Users.Username       AS CreatorUsername,
                Categories.Name      AS CategoryName,
                Categories.Color     AS CategoryColor
                FROM Topics
                INNER JOIN Users ON Users.ID=Topics.CreatorID
                INNER JOIN Categories ON Categories.ID=Topics.CategoryID
                ORDER BY Topics.LastActivity DESC";

            var topics = _connection.Query<TopicDTO>(sql).ToList();

            return topics;
        }

        public IList<TopicDTO> GetTopicsByCategory(int categoryID)
        {
            string sql = $@"SELECT
                Topics.ID            AS ID,
                Topics.Title         AS Title,
                Topics.CreatorID     AS CreatorID,
                Topics.CategoryID    AS CategoryID,
                Topics.DateCreated   AS DateCreated,
                Topics.DateEdited    AS DateEdited,
                Topics.LastActivity  AS LastActivity,
                Topics.Description   AS Description,
                (SELECT COUNT(*)
                 FROM TopicLikes
                 WHERE TopicLikes.TopicID = Topics.ID)
                                     AS Likes,
                (SELECT COUNT(*)
                       FROM Comments
                       WHERE Comments.TopicID = Topics.ID)
                                     AS Replies,
                Topics.Closed        AS Closed,
                Users.Avatar         AS CreatorPicture,
                Users.Username       AS CreatorUsername,
                Categories.Name      AS CategoryName,
                Categories.Color     AS CategoryColor
                FROM Topics
                INNER JOIN Users ON Users.ID=Topics.CreatorID
                INNER JOIN Categories ON Categories.ID=Topics.CategoryID
                WHERE Topics.CategoryID = {categoryID}
                ORDER BY Topics.LastActivity DESC";

            var topics = _connection.Query<TopicDTO>(sql).ToList();

            return topics;
        }

        public TopicDTO LikeTopic(TopicLike topicLike)
        {
            string query = @"INSERT INTO TopicLikes (TopicID, UserID)
                             values(@TopicID, @UserID)
                             SELECT * 
                             FROM Topics 
                             WHERE Topics.ID = @TopicID";
            var topic = _connection.Query<TopicDTO>(query, new { topicLike.TopicID, topicLike.UserID }).FirstOrDefault();

            return topic;
        }

        public void UnlikeTopic(TopicLike topicLike)
        {
            string query = @"DELETE FROM TopicLikes 
                             WHERE TopicID = @TopicID 
                             AND UserID = @UserID";
            _connection.Execute(query, new { topicLike.TopicID, topicLike.UserID });
        }

        public void FollowTopic(TopicFollower topicFollower)
        {
            string query = @"INSERT INTO TopicFollowers (TopicID, FollowerID)
                             values(@TopicID, @FollowerID)";
            _connection.Execute(query, new { topicFollower.TopicID, topicFollower.FollowerID });
        }

        public void UnfollowTopic(TopicFollower topicFollower)
        {
            string query = @"DELETE FROM TopicFollowers 
                             WHERE TopicID = @TopicID 
                             AND FollowerID = @FollowerID";
            _connection.Execute(query, new { topicFollower.TopicID, topicFollower.FollowerID });
        }

        public void EditTopic(int topicID, string title, string description, DateTime date)
        {
            var sql = $@"UPDATE Topics
                         SET Topics.Title = @Title, Topics.Description = @Description, Topics.DateEdited = @Date, Topics.LastActivity = @Date
                         WHERE Topics.ID = @TopicID";
            _connection.Execute(sql, new { title, description, date, topicID });
        }

        public void ReportTopic(TopicReport report)
        {
            string query = @"INSERT INTO TopicReports (TopicID, ReporterID, Reason, DateCreated)
                             values(@TopicID, @ReporterID, @Reason, @DateCreated)";
            _connection.Execute(query, new { report.TopicID, report.ReporterID, report.Reason, report.DateCreated });
        }

        public void CloseTopic(int topicID)
        {
            bool closed = true;
            string query = @"UPDATE Topics 
                             SET Topics.Closed = @Closed
                             WHERE ID = @TopicID";
            _connection.Execute(query, new { closed, topicID });
        }

        public void DeleteTopic(int topicId)
        {
            string query = @"DELETE FROM Topics 
                             WHERE ID = @TopicID
                             DELETE FROM TopicReports 
                             WHERE TopicID = @TopicID";
            _connection.Execute(query, new { topicId });
        }

        public void DeleteTopicReport(int reportID)
        {
            string query = @"DELETE FROM TopicReports 
                             WHERE ID = @ReportID";
            _connection.Execute(query, new { reportID });
        }

        public IList<TopicReportDTO> GetTopicsReports()
        {
            string sql = @"SELECT 
                            TopicReports.ID             AS ID,
                            TopicReports.TopicID        AS TopicID,
                            TopicReports.ReporterID     AS ReporterID,
                            TopicReports.Reason         AS Reason,
                            TopicReports.DateCreated    AS DateCreated,
                            Users.Username              AS ReporterUsername,
                            Topics.Title                AS TopicTitle
                            FROM TopicReports
                            INNER JOIN Users ON Users.ID=TopicReports.ReporterID
                            INNER JOIN Topics ON Topics.ID=TopicReports.TopicID
                            ORDER BY TopicReports.DateCreated DESC";

            var reports = _connection.Query<TopicReportDTO>(sql).ToList();
            return reports;
        }
    }
}
