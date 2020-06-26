using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praksa.Common
{
    class Sort
    {
        public string OrderBy { get; set; } //name / surname
        public string Order { get; set; } // ascending / descending
        public Sort()
        {
            OrderBy = "surname";
        }
    }
}
