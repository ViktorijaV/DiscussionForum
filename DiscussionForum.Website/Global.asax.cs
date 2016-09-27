using System;
using System.Web.Routing;

namespace DiscussionForum
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("CreateTopicRoute", "topic/create", "~/Site/CreateTopic.aspx");
            routes.MapPageRoute("TopicRoute", "topic/{id}", "~/Site/Topic.aspx");
            routes.MapPageRoute("EditTopicRoute", "topic/{id}/edit", "~/Site/EditTopic.aspx");
            routes.MapPageRoute("CreateCategoryRoute", "admin/category/create", "~/Site/Admin/CreateCategory.aspx");
            routes.MapPageRoute("DashboardRoute", "admin/dashboard", "~/Site/Admin/Dashboard.aspx");
            routes.MapPageRoute("CategoryRoute", "category/{id}", "~/Site/Category.aspx");
            routes.MapPageRoute("UserProfileRoute", "users/{username}", "~/Site/UserProfile.aspx");
            routes.MapPageRoute("EditProfileRoute", "profile/edit", "~/Site/EditProfile.aspx");
            routes.MapPageRoute("NotificationsRoute", "profile/notifications", "~/Site/Notifications.aspx");
            routes.MapPageRoute("ConfirmationRoute", "confirmation", "~/Site/Confirmation.aspx");
            routes.MapPageRoute("ForgotPasswordRoute", "forgotpassword", "~/Site/ForgotPassword.aspx");
            routes.MapPageRoute("ResetPasswordRoute", "resetpassword", "~/Site/ResetPassword.aspx");
            routes.MapPageRoute("RegisterRoute", "register", "~/Site/Register.aspx");
            routes.MapPageRoute("LoginRoute", "login", "~/Site/Login.aspx");
            routes.MapPageRoute("AccessDeniedRute", "accessdenied", "~/Site/AccessDenied.aspx");
            routes.MapPageRoute("HomePageRoute2", "home", "~/Site/Home.aspx");
            routes.MapPageRoute("HomePageRoute", "", "~/Site/Home.aspx");
        }
    }
}