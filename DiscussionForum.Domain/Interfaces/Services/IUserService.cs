using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscussionForum.Domain.DomainModel;

namespace DiscussionForum.Domain.Interfaces.Services
{
    public interface IUserService
    {
        void RegisterUser(User user);
        string CheckForExistingUser(string email);
    }
}
