using DiscussionForum.Domain.DomainModel;
using DiscussionForum.Domain.DTOs;
using System.Collections.Generic;

namespace DiscussionForum.Domain.Interfaces.Services
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
