using System;

namespace DiscussionForum.Domain.DomainModel
{
    public class Category
    {
        protected Category() { }

        public Category(string name, string color)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name is requeried!");
            if (string.IsNullOrEmpty(color))
                throw new Exception("Color is required!");
            if (name.Length > 50)
                throw new Exception("Name is too long!");
            Name = name;
            Color = color;
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Color { get; private set; }
    }
}