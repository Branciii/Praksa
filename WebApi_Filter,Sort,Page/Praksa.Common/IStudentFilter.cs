using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praksa.Common
{
    public interface IStudentFilter
    {
        string FilterString { get; set; }
        void StringToNameAndSurname();
        bool EmptyFilterString();
    }
}
