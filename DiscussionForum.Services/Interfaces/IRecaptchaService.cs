using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionForum.Services.Interfaces
{
    public interface IRecaptchaService
    {
        bool validateRecaptcha(string response);
    }
}
