using DiscussionForum.Services;
using DiscussionForum.Services.Intefraces;
using DiscussionForum.Services.Interfaces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace DiscussionForum.Site
{
    public partial class EditProfile : System.Web.UI.Page
    {
        private IUserService _userService = new UserService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private IFileService _fileService = new FileService(HttpContext.Current.Server.MapPath("/"));

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            if (currentUser == null)
                Response.Redirect("~/login?ReturnUrl=%2fprofile%2fedit");
            if (!IsPostBack)
                fillData(currentUser.Id);
        }

        private void fillData(int id)
        {
            var user = _userService.GetUserById(id);
            ID.Value = user.ID.ToString();
            Username.Value = user.Username;
            Avatar.Value = user.Avatar;
            txtFullName.Text = user.Fullname;
            string bio = Server.HtmlDecode(user.Bio).Replace("\"", "'");
            txtBio.Text = bio;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var userId = int.Parse(ID.Value);
            var fullname = txtFullName.Text;
            var avatar = Avatar.Value;
            
            if(imageUpload.HasFile)
            {
                var file = imageUpload.PostedFile;
                if (!file.ContentType.Contains("image"))
                {
                    error.InnerText = "Please select an image when you upload a file.";
                    error.Attributes.CssStyle.Remove("display");
                    return;
                }
                if(file.ContentLength > 2097152)
                {
                    error.InnerText = "Please select an image less than .";
                    error.Attributes.CssStyle.Remove("display");
                    return;
                }

                var extension = Path.GetExtension(file.FileName);
                var filebytes = getBytesFromFile(file);

                var filename = $"user-{Username.Value}{extension}";

                _fileService.SaveFile(ConfigurationManager.AppSettings["containerForUserImages"], filename, filebytes);

                avatar = $"{ConfigurationManager.AppSettings["rootForUserImages"]}/{filename}";
            }

            var bio = txtBio.Text;
            _userService.ChangeUserProperties(userId, fullname, bio, avatar);

            Response.Redirect($"/users/{Username.Value}");
        }

        private byte[] getBytesFromFile(HttpPostedFile file)
        {
            byte[] data;
            using (Stream inputStream = file.InputStream)
            {
                MemoryStream memoryStream = new MemoryStream();
                inputStream.CopyTo(memoryStream);
                data = memoryStream.ToArray();
            }
            return data;
        }
    }
}