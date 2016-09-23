using Dapper;
using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Domain.DTOs;
using DiscussionForum.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DiscussionForum.Services
{
    public class CategoryService : ICategoryService
    {
        private IDbConnection _connection { get; set; }

        public CategoryService(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateCategory(Category category)
        {
            string query = "INSERT INTO Categories (Name, Color)" +
            "values(@Name, @Color)";
            _connection.Execute(query, new { category.Name, category.Color });
        }
        public IList<Category> LoadCategories()
        {
            string sql = $"SELECT * FROM Categories";
            var categories = _connection.Query<DiscussionForum.Domain.DomainModel.Category>(sql).ToList();
            return categories;
        }

        public Category GetCategoryById(int categoryID)
        {
            string sql = $@"SELECT * FROM Categories
                WHERE Categories.ID = {categoryID}";
            var category = _connection.Query<Category>(sql).FirstOrDefault();

            return category;
        }

        public void FollowCategory(CategoryFollower categoryFollower)
        {
            string query = @"INSERT INTO CategoryFollowers (CategoryID, FollowerID)
                             values(@CategoryID, @FollowerID)";
            _connection.Execute(query, new { categoryFollower.CategoryID, categoryFollower.FollowerID });
        }

        public void UnfollowCategory(CategoryFollower categoryFollower)
        {
            string query = @"DELETE FROM CategoryFollowers 
                             WHERE CategoryID = @CategoryID 
                             AND FollowerID = @FollowerID";
            _connection.Execute(query, new { categoryFollower.CategoryID, categoryFollower.FollowerID });
        }

        public IList<CategoryFollowerDTO> GetFollowers(int categoryID)
        {
            string sql = $@"SELECT
                CategoryFollowers.FollowerID    AS FollowerID,
                Users.Avatar                    AS FollowerPicture,
                Users.Username                  AS FollowerUsername,
                Users.Fullname                  AS FollowerFullname
                FROM CategoryFollowers
                INNER JOIN Users ON Users.ID=CategoryFollowers.FollowerID
                WHERE CategoryFollowers.CategoryID = {categoryID}";

            var followers = _connection.Query<CategoryFollowerDTO>(sql).ToList();

            return followers;
        }
    }
}
