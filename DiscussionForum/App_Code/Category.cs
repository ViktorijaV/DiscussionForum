using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.App_Code
{
    public class Category
    {
        protected Category() { }

        public Category(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Color { get; private set; }
    }
}