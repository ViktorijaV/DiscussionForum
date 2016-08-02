using System;
using DiscussionForum.App_Code;

namespace DiscussionForum
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            User user;
            if (male.Checked == true)
                user = DiscussionForum.App_Code.User.RegisterUser(txtEmail.Text, txtFullName.Text, txtPassword.Text, txtRepeatPassword.Text, Gender.Male, Convert.ToDateTime(txtBirthday.Text));
            else
                user = DiscussionForum.App_Code.User.RegisterUser(txtEmail.Text, txtFullName.Text, txtPassword.Text, txtRepeatPassword.Text, Gender.Female, Convert.ToDateTime(txtBirthday.Text));
        }
    }
}