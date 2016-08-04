using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionForum.App_Code
{
    public class Category
    {
        public Category(string name)
        {
            Name = name;
        }
        public int ID { get; private set; }
        public string Name { get; private set; }
    }
}