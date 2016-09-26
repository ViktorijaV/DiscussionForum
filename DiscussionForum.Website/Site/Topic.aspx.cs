using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace DiscussionForum.Site
{
    public partial class Topic : System.Web.UI.Page
    {
        private ICommentService _commentService = new CommentService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private ITopicService _topicService = new TopicService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private INotificationService _notificationService = new NotificationService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);
            var currentUser = _authenticationService.GetAuthenticatedUser();
            loadTopic(topicID, currentUser);
            loadComments(topicID, currentUser);
        }

        private void loadTopic(int topicID, AuthenticatedUser currentUser)
        {

            var currentUserId = 0;
            if (currentUser != null)
                currentUserId = currentUser.Id;

            var topicDetails = _topicService.GetTopicById(topicID, currentUserId);

            btnUnfollow.Style.Add("display", "none");
            btnFollow.Style.Add("display", "inline-block");
            btnUnlike.Style.Add("display", "none");
            btnLike.Style.Add("display", "inline-block");

            if (currentUser != null)
            {
                if (topicDetails.CurrentUserFollows)
                {
                    btnFollow.Style.Add("display", "none");
                    btnUnfollow.Style.Add("display", "inline-block");
                }

                if (topicDetails.CurrentUserLikes)
                {
                    btnLike.Style.Add("display", "none");
                    btnUnlike.Style.Add("display", "inline-block");
                }

                if (currentUser.Id == topicDetails.CreatorID)
                {
                    var html = settingsDropdown.InnerHtml;
                    settingsDropdown.InnerHtml = $"<li><a id='editTopic' data-title='Edit your topic'><i class='fa fa-pencil fa-fw faa-spin'></i>Edit</a></li>{html}";
                }
            }

            topicTitle.Text = topicDetails.Title;
            creatorImg.ImageUrl = topicDetails.CreatorPicture;
            timeCreated.InnerText = TimePeriod.TimeDifference(topicDetails.DateCreated);
            creatorUsername.InnerText = topicDetails.CreatorUsername;

            if (topicDetails.DateEdited != DateTime.MinValue)
                timeEdited.InnerText = $"Edited {TimePeriod.TimeDifference(topicDetails.DateEdited)}";

            string description = Server.HtmlDecode(topicDetails.Description).Replace("\"", "'");
            topicDescription.InnerHtml = description;
            createdTime.Text = TimePeriod.TimeDifference(topicDetails.DateCreated);
            activeTime.Text = TimePeriod.TimeDifference(topicDetails.LastActivity);
            btnlikeNum.Text = topicDetails.Likes.ToString();
            numComments.InnerText = topicDetails.Replies.ToString();

            categoryLink.NavigateUrl = $"/category/{topicDetails.CategoryID}";
            categoryLink.Text = topicDetails.CategoryName;
            categoryLink.BackColor = System.Drawing.ColorTranslator.FromHtml(topicDetails.CategoryColor);

            Followers.InnerText = topicDetails.Followers.ToString();


        }

        private void loadComments(int topicID, AuthenticatedUser currentUser)
        {
            var currentUserId = 0;
            if (currentUser != null)
                currentUserId = currentUser.Id;


            var comments = _commentService.GetComments(topicID, currentUserId);

            CommentList.InnerHtml = "";

            foreach (var comment in comments)
            {
                var button = $"<button class='btn btn-icon faa-parent animated-hover' onclick='likeComment(this)'><i class='fa fa-star-o faa-tada'></i></button>";
                if (currentUser != null && comment.LikedByUser)
                    button = $"<button class='btn btn-icon faa-parent animated-hover' onclick='unlikeComment(this)'><i class='fa fa-star faa-tada'></i></button>";

                var edited = "";

                if (comment.DateEdited != DateTime.MinValue)
                    edited = $"<span>Edited {TimePeriod.TimeDifference(comment.DateEdited)}</span>";

                var editButton = "";

                if (currentUser != null && currentUser.Id == comment.CommenterID)
                    editButton = @"<button class='btn btn-icon faa-parent animated-hover pull-right edit-comment tool expand' data-title='Edit your comment' type='button'>
                                        <i class='fa fa-pencil faa-shake'></i>
                                    </button>";

                var content = Server.HtmlDecode(comment.Content).Replace("\"", "'");
                var li = $@"<li class='media'>
                                <a class='pull-left' href='/user/{comment.CommenterUsername}'>
                                    <img class='media-object img-rounded' src='{comment.CommenterPicture}' alt='profile'>
                                </a>
                                <div class='media-body'>
                                    <div class='well well-md'>
                                        <input type='hidden' class='comment-id' value='{comment.ID}'>
                                        <h4 class='media-heading'>{comment.CommenterUsername}</h4>
                                        <span>Created {TimePeriod.TimeDifference(comment.DateCreated)}</span>
                                        {editButton}
                                        <br />
                                        {edited}
                                        <div class='media-comment'>
                                            {content}
                                        </div>
                                        {button}<span class='span-number'>{comment.Likes}</span>
                                    </div>
                                </div>
                            </li>";
                CommentList.InnerHtml += li;
            }
        }

        protected void btnFollow_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                redirectToLogin(Request.RawUrl);

            var topicFollower = new TopicFollower(topicID, currentUser.Id);

            _topicService.FollowTopic(topicFollower);

            btnFollow.Style.Add("display", "none");
            btnUnfollow.Style.Add("display", "inline-block");
            var num = int.Parse(Followers.InnerText);
            Followers.InnerText = (num + 1).ToString();

        }

        protected void btnUnfollow_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                redirectToLogin(Request.RawUrl);

            var topicFollower = new TopicFollower(topicID, currentUser.Id);

            _topicService.UnfollowTopic(topicFollower);

            btnUnfollow.Style.Add("display", "none");
            btnFollow.Style.Add("display", "inline-block");
            var num = int.Parse(Followers.InnerText);
            Followers.InnerText = (num - 1).ToString();
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                redirectToLogin(Request.RawUrl);

            var topicLike = new TopicLike(topicID, currentUser.Id);

            var topic = _topicService.LikeTopic(topicLike);
            string message = $@"{currentUser.FullName} liked your topic <a href='/topic/{topicID}'>{topic.Title}</a>.";
            Notification notification = new Notification(topic.CreatorID, message, DateTime.Now);
            _notificationService.CreateNotification(notification);

            btnLike.Style.Add("display", "none");
            btnUnlike.Style.Add("display", "inline-block");
            var num = int.Parse(btnlikeNum.Text);
            btnlikeNum.Text = (num + 1).ToString();
        }

        protected void btnUnlike_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                redirectToLogin(Request.RawUrl);

            var topicLike = new TopicLike(topicID, currentUser.Id);

            _topicService.UnlikeTopic(topicLike);

            btnUnlike.Style.Add("display", "none");
            btnLike.Style.Add("display", "inline-block");
            var num = int.Parse(btnlikeNum.Text);
            btnlikeNum.Text = (num - 1).ToString();
        }

        protected void btnCreateComment_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                redirectToLogin(Request.RawUrl);

            var content = Server.HtmlEncode(txtComment.Text);
            var comment = new Comment(topicID, currentUser.Id, txtComment.Text);

            var topic = _topicService.GetTopicById(topicID, currentUser.Id);
            string message = $@"{currentUser.FullName} commented on your topic <a href='/topic/{topicID}'>{topic.Title}</a>.";
            Notification notification = new Notification(topic.CreatorID, message, DateTime.Now);
            _notificationService.CreateNotification(notification);

            _commentService.CreateComment(comment);

            loadComments(topicID, currentUser);
        }

        protected void btnLikeComment_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                redirectToLogin(Request.RawUrl);

            var commentId = commentID.Value;
            _commentService.LikeComment(currentUser.Id, int.Parse(commentId));

            loadComments(topicID, currentUser);
        }

        protected void btnUnlikeComment_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                redirectToLogin(Request.RawUrl);

            var commentId = commentID.Value;
            _commentService.UnlikeComment(currentUser.Id, int.Parse(commentId));

            loadComments(topicID, currentUser);
        }

        protected void btnEditComment_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                redirectToLogin(Request.RawUrl);

            var Id = commentID.Value;
            var content = Server.HtmlEncode(txtContent.Text);
            content = txtContent.Text;
            var date = DateTime.Now;
            _commentService.EditComment(topicID, Id, content, date);

            loadComments(topicID, currentUser);
        }

        protected void btnEditTopic_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            int topicID = Convert.ToInt32(Page.RouteData.Values["id"]);

            if (currentUser == null)
                redirectToLogin(Request.RawUrl);

            var title = txtEditTitle.Text;
            var description = Server.HtmlEncode(txtEditDesc.Text);
            description = txtEditDesc.Text;
            var date = DateTime.Now;

            _topicService.EditTopic(topicID, title, description, date);

            topicTitle.Text = title;
            description = Server.HtmlDecode(description).Replace("\"", "'");
            topicDescription.InnerHtml = description;
            timeEdited.InnerText = $"Edited {TimePeriod.TimeDifference(date)}";
            activeTime.Text = TimePeriod.TimeDifference(date);
        }

        private void redirectToLogin(string url)
        {
            Response.Redirect($"~/login?ReturnUrl={Server.UrlEncode(url)}");
        }
    }
}