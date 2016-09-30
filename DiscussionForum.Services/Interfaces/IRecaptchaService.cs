using System;

namespace DiscussionForum.Services.Interfaces
{
    public interface IRecaptchaService
    {
        bool validateRecaptcha(string response);
    }
}
