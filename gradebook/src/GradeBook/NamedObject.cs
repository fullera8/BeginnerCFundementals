using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{        
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }
        
        public string Name
        {
            get;set;
        }
    }
}