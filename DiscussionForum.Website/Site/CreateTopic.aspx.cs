﻿using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using DiscussionForum.Services;
using DiscussionForum.Services.Interfaces;
using DiscussionForum.Domain.DomainModel;

namespace DiscussionForum.Site
{
    public partial class CreateTopic : System.Web.UI.Page
    {
        private ITopicService _topicService = new TopicService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private ICategoryService _categoryService = new CategoryService(new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));
        private FormsAuthenticationService _authenticationService = new FormsAuthenticationService(HttpContext.Current, new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()));

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = _authenticationService.GetAuthenticatedUser();
            if (user == null)
                Response.Redirect("~/login?ReturnUrl=%2ftopic%2fcreate");
            currentUser.ImageUrl = user.PhotoUrl;
            loadCategories();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();
            var description = Server.HtmlEncode(txtDescription.Text);
            var topic = new DiscussionForum.Domain.DomainModel.Topic(currentUser.Id, int.Parse(ddlCategories.SelectedItem.Value), txtTitle.Text, description);

            int topicId = _topicService.CreateTopic(topic);

            var topicFollower = new TopicFollower(topicId, currentUser.Id);
            _topicService.FollowTopic(topicFollower);
            
            Response.RedirectToRoute("TopicRoute", new { id = topicId });
        }

        private void loadCategories()
        {
            var categories = _categoryService.LoadCategories();

            foreach (var category in categories)
            {
                ddlCategories.Items.Add(new ListItem(category.Name, category.ID.ToString()));
            }
        }
    }
}