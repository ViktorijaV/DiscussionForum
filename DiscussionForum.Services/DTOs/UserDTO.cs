using DiscussionForum.Domain.DomainModel;
using System;

namespace DiscussionForum.Services.DTOs
{
    public class UserDTO
    {
        public int ID { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Fullname { get; private set; }
        public DateTime DateCreated { get; private set; }
        public Role Role { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Avatar { get; private set; }
        public string Bio { get; private set; }
        public bool Blocked { get; private set; }
        public int NumTopics { get; private set; }
        public int NumComments { get; private set; }
    }
}