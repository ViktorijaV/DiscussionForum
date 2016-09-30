using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services;
using DiscussionForum.Services.Intefraces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace DiscussionForum.Site
{
    public partial class UserProfile : System.Web.UI.Page
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = Page.RouteData.Values["username"].ToString();
            getUser(username);
        }

        private void getUser(string userName)
        {
            var user = _userService.GetUserByUsername(userName);
            var currentUser = _authenticationService.GetAuthenticatedUser();

            if (currentUser == null)
            {
                Response.Redirect($"/login?ReturnUrl={Request.RawUrl}");
            }

            if (currentUser.Id != user.ID)
                btnEdit.Style["display"] = "none";

            var userDetails = _userService.GetUserDetails(user.ID);
            profilePicture.ImageUrl = userDetails.Avatar;
            username.Text = userDetails.Username;
            fullname.Text = userDetails.Fullname;
            gender.Text = userDetails.Gender.ToString();
            age.Text = TimePeriod.GetAge(userDetails.Birthdate).ToString();
            bio.Text = userDetails.Bio;
            topics.Text = userDetails.NumTopics.ToString();
            comments.Text = userDetails.NumComments.ToString();
        }
    }
}