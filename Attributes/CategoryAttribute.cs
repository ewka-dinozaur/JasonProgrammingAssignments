using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{

    public class CategoryAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }

        public CategoryAttribute(string name, string description = "")
        {
            Name = name;
            Description = description;
        }
    }
}