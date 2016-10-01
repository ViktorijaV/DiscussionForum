using System;

namespace DiscussionForum.Domain.DomainModel
{
    public class Topic
    {

        public Topic(int creatorId, int categoryId, string title, string description)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception("Title is required!");
            if (title.Length > 50)
                throw new Exception("Title should be less that 50 charachters long!");
            if (string.IsNullOrEmpty(description))
                throw new Exception("Description is required!");
            if (description.Length > 5000)
                throw new Exception("Description should be less that 5000 charachters long!");
            CreatorID = creatorId;
            CategoryID = categoryId;
            Title = title;
            Description = description;
            DateCreated = DateTime.Now;
            LastActivity = DateCreated;
            Closed = false;
            DateEdited = null;
        }

        public int ID { get; private set; }
        public int CreatorID { get; private set; }
        public int CategoryID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateEdited { get; private set; }
        public DateTime LastActivity { get; private set; }
        public bool Closed { get; private set; }
    }
}