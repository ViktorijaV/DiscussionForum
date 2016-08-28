using System;

namespace DiscussionForum.AppServices
{
    public class AuthenticatedUser
    {
        public AuthenticatedUser(string fullname, string username, int id, string photoUrl, string role)
        {
            FullName = fullname;
            Username = username;
            Id = id;
            PhotoUrl = photoUrl;
            Role = role;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Username { get; private set; }
        public string PhotoUrl { get; set; }
        public string Role { get; private set; } 
    }
}