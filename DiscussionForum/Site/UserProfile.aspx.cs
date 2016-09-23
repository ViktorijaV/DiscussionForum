using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Domain.Interfaces.Services;
using DiscussionForum.Services;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace DiscussionForum.Site
{
    public partial class UserProfile : System.Web.UI.Page
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()), new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString())));

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = Page.RouteData.Values["username"].ToString();
            getUser(username);
        }

        private void getUser(string userName)
        {
            var user = _userService.GetUserByUsername(userName);
            profilePicture.ImageUrl = user.Avatar;
            username.Text = user.Username;
            fullname.Text = user.Fullname;
            gender.Text = user.Gender.ToString();
            age.Text = TimePeriod.GetAge(user.Birthdate).ToString();
            bio.Text = user.Bio;
        }
    }
}