using System;
using System.Text.RegularExpressions;

namespace DiscussionForum.App_Code
{
    public class User
    {
        protected User()
        {
            DateCreated = DateTime.Now;
            Confirmed = false;
        }

        public static User RegisterUser(string email, string fullName, string password, string repeatedPassword, Gender gender, DateTime birthday, string avatarUrl = "", string country = "", string faculty = "")
        {
            var user = new User();

            if (!isValidEmail(email))
                throw new Exception("Invalid email");

            if (!isValidFullName(fullName))
                throw new Exception("Invalid full name");

            if (!IsValidPassword(password))
                throw new Exception("Invalid password");

            if (password != repeatedPassword)
                throw new Exception("Passwords doesn't match");

            user.Email = email;
            user.Password = password; // TODO: encrypt password
            user.ConfirmationCode = Guid.NewGuid().ToString();
            user.Role = Role.User;
            user.Gender = gender;
            user.Birthdate = birthday;
            user.Avatar = avatarUrl;
            user.Country = country;
            user.Faculty = faculty;
            user.Location = null;

            return user;
        }

        private static bool isValidEmail(string email)
        {
            const string VALID_EMAIL_REGEX = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            if (Regex.IsMatch(email, VALID_EMAIL_REGEX))
                return true;

            return false;
        }

        private static bool isValidFullName(string fullName)
        {
            const string VALID_FULLNAME_REGEX = @"([A-Za-z -]+){6,20}";
            if (Regex.IsMatch(fullName, VALID_FULLNAME_REGEX))
                return true;

            return false;
        }

        private static bool IsValidPassword(string password)
        {
            if (Regex.IsMatch(password, @"((?=.*\w)(?=.*[!#$%&'()*+,-./:;<=>?@[\]^_`{|}~]).{6,16})"))
                return true;

            return false;
        }

        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Confirmed { get; set; }
        public string ConfirmationCode { get; set; }
        public Role Role { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Avatar { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Faculty { get; set; }
    }
    public enum Role
    {
        User, Admin
    }
    public enum Gender
    {
        Male, Female
    }
}