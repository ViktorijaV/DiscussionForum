using DiscussionForum.Domain.DomainModel;
using System;

namespace DiscussionForum.Domain.Interfaces.Services
{
    public interface IUsernameGenerator
    {
        void addUsernameToUser(User user);
    }
}
