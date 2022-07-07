using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IcefPropertyAttribute : Attribute
    {
        public string Name { get; private set; }

        public IcefPropertyAttribute(string name)
        {
            Name = name;
        }
    }
}
