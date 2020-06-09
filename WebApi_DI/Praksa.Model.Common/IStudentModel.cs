using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Common
{
    public interface IStudentModel
    {
        Guid id { get; set; }
        string name { get; set; }
        string surname { get; set; }
    }
}
