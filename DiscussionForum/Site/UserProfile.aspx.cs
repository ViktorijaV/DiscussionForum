using Dapper;
using DiscussionForum.App_Code;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace DiscussionForum.Site
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            var username = Page.RouteData.Values["username"].ToString();
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
            getUser(connection, username);
            */
        }

        private void getUser(SqlConnection connection, string userName)
        {
            var sql = $@"SELECT * FROM Users
                         WHERE Users.Username = '{userName}'";
            var user = connection.Query<User>(sql).FirstOrDefault();
            profilePicture.ImageUrl = user.Avatar;
            username.Text = user.Username;
            fullname.Text = user.Fullname;
            gender.Text = user.Gender.ToString();
            age.Text = TimePeriod.GetAge(user.Birthdate).ToString();
            bio.Text = user.Bio;
        }
    }
}