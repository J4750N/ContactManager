using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class PhoneType
    {
        public List<string> TypeCollection { get; set; }

        public PhoneType()
        {
            TypeCollection = new List<string>()
            {
                "Home",
                "Cell",
                "Work"
            };
    }
    }
}
