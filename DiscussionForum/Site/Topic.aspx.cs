using Dapper;
using DiscussionForum.App_Code;
using DiscussionForum.AppServices;
using DiscussionForum.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForum.Site
{
    public partial class Topic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);
            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var currentUser = new FormsAuthenticationService(HttpContext.Current, sqlConnection).GetAuthenticatedUser();
            loadTopic(sqlConnection, topicID, currentUser);
        }

        private void loadTopic(SqlConnection connection, int topicID, AuthenticatedUser currentUser)
        {
            var sqlQueryTopic = $@"SELECT
                                   Topics.ID                AS ID,
                                   Topics.Title             AS Title,
                                   Topics.CreatorID         AS CreatorID,
                                   Topics.CategoryID        AS CategoryID,
                                   Topics.DateCreated       AS DateCreated,
                                   Topics.LastActivity      AS LastActivity,
                                   Topics.Description       AS Description,
                                   Topics.Reported          AS Reported,
                                   Topics.Closed            AS Closed,
                                   Users.Avatar             AS CreatorPicture,
                                   Users.Username           AS CreatorUsername,
                                   Categories.Name          AS CategoryName,
                                   Categories.Color         AS CategoryColor,
                                   (SELECT COUNT(*)
                                          FROM TopicFollowers
                                          WHERE TopicFollowers.TopicID = {topicID})
                                                            AS Folowers,
                                   (SELECT COUNT(*)
                                    FROM TopicLikes
                                    WHERE TopicLikes.TopicID = {topicID})
                                                            AS Likes,
                                   (SELECT COUNT(*)
                                          FROM Comments
                                          WHERE Comments.TopicID = {topicID})
                                                            AS Replies
                                   FROM Topics
                                   INNER JOIN Users ON Users.ID=Topics.CreatorID
                                   INNER JOIN Categories ON Categories.ID=Topics.CategoryID
                                   WHERE Topics.ID = {topicID}";
            var sqlQueryComments = $@"SELECT
                                        Comments.ID              AS ID,
                                        Comments.TopicID         AS TopicID,
                                        Comments.CommenterID     AS CommenterID,
                                        Comments.Content         AS Content,
                                        Comments.DateCreated     AS DateCreated,
                                        Users.Avatar             AS CommenterPicture,
                                        Users.Username           AS CommenterUsername,
                                        (SELECT COUNT(*)
                                        FROM CommentLikes
                                        WHERE CommentLikes.CommentID = Comments.ID)
                                                                 AS Likes
                                        FROM Comments
                                        INNER JOIN Users ON Users.ID=Comments.CommenterID
                                        WHERE Comments.TopicID = {topicID}";
            var grid = connection.QueryMultiple(String.Format("{0}\n{1}", sqlQueryTopic, sqlQueryComments));

            var topicDetails = grid.Read<TopicDTO>().FirstOrDefault();
            var comments = grid.Read<CommentDTO>().ToList();

            btnUnfollow.Style.Add("display", "none");
            btnFollow.Style.Add("display", "inline-block");
            btnUnlike.Style.Add("display", "none");
            btnLike.Style.Add("display", "inline-block");

            if (currentUser != null)
            {
                var sqlFollowerCurrentUser = $@"SELECT CAST(COUNT(1) AS BIT)
                                            FROM TopicFollowers
                                            WHERE TopicFollowers.TopicID = {topicID} AND TopicFollowers.FollowerID = {currentUser.Id}";
                var sqlLikerCurrentUser = $@"SELECT CAST(COUNT(1) AS BIT)
                                            FROM TopicLikes
                                            WHERE TopicLikes.TopicID = {topicID} AND TopicLikes.UserID = {currentUser.Id}";
                var gridBollean = connection.QueryMultiple(String.Format("{0}\n{1}", sqlFollowerCurrentUser, sqlLikerCurrentUser));
                var follows = gridBollean.Read<bool>().FirstOrDefault();
                if (follows)
                {
                    btnFollow.Style.Add("display", "none");
                    btnUnfollow.Style.Add("display", "inline-block");
                }
                var likes = gridBollean.Read<bool>().FirstOrDefault();
                if (likes)
                {
                    btnLike.Style.Add("display", "none");
                    btnUnlike.Style.Add("display", "inline-block");
                }
            }

            topicTitle.Text = topicDetails.Title;
            creatorImg.ImageUrl = topicDetails.CreatorPicture;

            string description = Server.HtmlDecode(topicDetails.Description).Replace("\"", "'");
            topicDescription.InnerHtml = description;
            createdTime.Text = TimePeriod.TimeDifference(topicDetails.DateCreated);
            activeTime.Text = TimePeriod.TimeDifference(topicDetails.LastActivity);
            btnLike.Text = topicDetails.Likes.ToString();
            btnUnlike.Text = topicDetails.Likes.ToString();
            numComments.InnerText = topicDetails.Replies.ToString();

            categoryLink.NavigateUrl = $"/category/{topicDetails.CategoryID}";
            categoryLink.Text = topicDetails.CategoryName;
            categoryLink.BackColor = System.Drawing.ColorTranslator.FromHtml(topicDetails.CategoryColor);

            Followers.InnerText = topicDetails.Followers.ToString();
        }

        protected void btnFollow_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var currentUser = new FormsAuthenticationService(HttpContext.Current, connection).GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                Response.Redirect($"~/login?ReturnUrl=%2ftopic%2f{topicID}");

            var topicFollower = new TopicFollower(topicID, currentUser.Id);

            string query = @"INSERT INTO TopicFollowers (TopicID, FollowerID)
                             values(@TopicID, @FollowerID)";
            connection.Execute(query, new { topicFollower.TopicID, topicFollower.FollowerID });

            btnFollow.Style.Add("display", "none");
            btnUnfollow.Style.Add("display", "inline-block");
            var num = int.Parse(Followers.InnerText);
            Followers.InnerText = (num + 1).ToString();

        }

        protected void btnUnfollow_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var currentUser = new FormsAuthenticationService(HttpContext.Current, connection).GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                Response.Redirect($"~/login?ReturnUrl=%2ftopic%2f{topicID}");

            var topicFollower = new TopicFollower(topicID, currentUser.Id);

            string query = @"DELETE FROM TopicFollowers 
                             WHERE TopicID = @TopicID 
                             AND FollowerID = @FollowerID";
            connection.Execute(query, new { topicFollower.TopicID, topicFollower.FollowerID });

            btnUnfollow.Style.Add("display", "none");
            btnFollow.Style.Add("display", "inline-block");
            var num = int.Parse(Followers.InnerText);
            Followers.InnerText = (num - 1).ToString();
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var currentUser = new FormsAuthenticationService(HttpContext.Current, connection).GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                Response.Redirect($"~/login?ReturnUrl=%2ftopic%2f{topicID}");

            var topicLike = new TopicLike(topicID, currentUser.Id);

            string query = @"INSERT INTO TopicLikes (TopicID, UserID)
                             values(@TopicID, @UserID)";
            connection.Execute(query, new { topicLike.TopicID, topicLike.UserID });

            btnLike.Style.Add("display", "none");
            btnUnlike.Style.Add("display", "inline-block");
            var num = int.Parse(btnLike.Text);
            btnLike.Text = (num + 1).ToString();
            btnUnlike.Text = (num + 1).ToString();
        }

        protected void btnUnlike_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var currentUser = new FormsAuthenticationService(HttpContext.Current, connection).GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                Response.Redirect($"~/login?ReturnUrl=%2ftopic%2f{topicID}");

            var topicLike = new TopicLike(topicID, currentUser.Id);

            string query = @"DELETE FROM TopicLikes 
                             WHERE TopicID = @TopicID 
                             AND UserID = @UserID";
            connection.Execute(query, new { topicLike.TopicID, topicLike.UserID });

            btnUnlike.Style.Add("display", "none");
            btnLike.Style.Add("display", "inline-block");
            var num = int.Parse(btnLike.Text);
            btnLike.Text = (num - 1).ToString();
            btnUnlike.Text = (num - 1).ToString();
        }

        protected void btnCreateComment_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var authenticationService = new FormsAuthenticationService(HttpContext.Current, connection);
            var currentUser = authenticationService.GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                Response.Redirect($"~/login?ReturnUrl=%2ftopic%2f{topicID}");

            var content = Server.HtmlEncode(txtComment.Text);
            var comment = new Comment(topicID, currentUser.Id, txtComment.Text);
            var sql = @"INSERT INTO Comments (TopicID, CommenterID, Content, Reported, Closed, DateCreated)
                        values(@TopicID, @CommenterID, @Content, @Reported, @Closed, @DateCreated)";
            connection.Execute(sql, new { comment.TopicID, comment.CommenterID, comment.Content, comment.Reported, comment.Closed, comment.DateCreated });

            Response.RedirectToRoute("TopicRoute", new { id = topicID });
        }
    }
}