using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Services.DTOs;
using System.Collections.Generic;

namespace DiscussionForum.Services.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(Category category);

        IList<Category> LoadCategories();

        Category GetCategoryById(int categoryID);

        void FollowCategory(CategoryFollower categoryFollower);

        void UnfollowCategory(CategoryFollower categoryFollower);

        IList<CategoryFollowerDTO> GetFollowers(int categoryID);
    }
}
