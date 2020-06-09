using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;

namespace ProjectModel
{
    public class StudentModel : IStudentModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

    }
}
