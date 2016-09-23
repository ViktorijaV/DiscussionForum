using DiscussionForum.Domain.DomainModel;
using System;

namespace DiscussionForum.Domain.Interfaces
{
    public interface IUsernameGenerator
    {
        string GenerateUsername(string email);
    }
}
