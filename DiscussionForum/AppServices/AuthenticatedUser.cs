using System;

namespace DiscussionForum.AppServices
{
    public class AuthenticatedUser
    {
        public AuthenticatedUser(string fullname, int id, string photoUrl, string role)
        {
            FullName = fullname;
            Id = id;
            PhotoUrl = photoUrl;
            Role = role;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string PhotoUrl { get; set; }
        public string Role { get; private set; } 
    }
}