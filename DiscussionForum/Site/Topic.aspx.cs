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
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);
            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            var currentUser = new FormsAuthenticationService(HttpContext.Current, sqlConnection).GetAuthenticatedUser();
            loadTopic(sqlConnection, topicID, currentUser);
        }

        private void loadTopic(SqlConnection connection, int topicID, AuthenticatedUser currentUser)
        {
            var sqlQueryTopic = $@"SELECT
                                   Topics.ID            AS ID,
                                   Topics.Title         AS Title,
                                   Topics.CreatorID     AS CreatorID,
                                   Topics.CategoryID    AS CategoryID,
                                   Topics.DateCreated   AS DateCreated,
                                   Topics.LastActivity  AS LastActivity,
                                   Topics.Description   AS Description,
                                   Topics.Likes         AS Likes,
                                   Topics.Replies       AS Replies,
                                   Topics.Reported      AS Reported,
                                   Topics.Closed        AS Closed,
                                   Users.Avatar         AS CreatorPicture,
                                   Users.Username       AS CreatorUsername,
                                   Categories.Name      AS CategoryName,
                                   Categories.Color     AS CategoryColor
                                   FROM Topics
                                   INNER JOIN Users ON Users.ID=Topics.CreatorID
                                   INNER JOIN Categories ON Categories.ID=Topics.CategoryID
                                   WHERE Topics.ID = {topicID}";
            var sqlQueryNumFollowers = $@"SELECT COUNT(*)
                                          FROM TopicFollowers
                                          WHERE TopicFollowers.TopicID = {topicID}";
            var grid = connection.QueryMultiple(String.Format("{0}\n{1}", sqlQueryTopic, sqlQueryNumFollowers));

            var topicDetails = grid.Read<TopicDTO>().FirstOrDefault();
            var numFollowers = grid.Read<int>().FirstOrDefault();

            btnUnfollow.Style.Add("display", "none");
            btnFollow.Style.Add("display", "inline-block");

            if (currentUser != null)
            {
                var sqlFollowerCurrentUser = $@"SELECT CAST(COUNT(1) AS BIT)
                                            FROM TopicFollowers
                                            WHERE TopicFollowers.TopicID = {topicID} AND TopicFollowers.FollowerID = {currentUser.Id}";
                var follows = connection.Query<bool>(sqlFollowerCurrentUser).FirstOrDefault();
                if (follows)
                {
                    btnFollow.Style.Add("display", "none");
                    btnUnfollow.Style.Add("display", "inline-block");
                }
            }

            topicTitle.Text = topicDetails.Title;
            creatorImg.ImageUrl = topicDetails.CreatorPicture;

            string description = Server.HtmlDecode(topicDetails.Description).Replace("\"", "'");
            topicDescription.InnerHtml = description;
            createdTime.Text = TimePeriod.TimeDifference(topicDetails.DateCreated);
            activeTime.Text = TimePeriod.TimeDifference(topicDetails.LastActivity);

            categoryLink.NavigateUrl = $"/category/{topicDetails.CategoryID}";
            categoryLink.Text = topicDetails.CategoryName;
            categoryLink.BackColor = System.Drawing.ColorTranslator.FromHtml(topicDetails.CategoryColor);

            Followers.InnerText = numFollowers.ToString();
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
    }
}