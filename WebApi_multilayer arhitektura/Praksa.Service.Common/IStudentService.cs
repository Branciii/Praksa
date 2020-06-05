using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectModel;

namespace Praksa.Service.Common
{
    public interface IStudentService
    {
        List<StudentModel> ReadData();

        List<StudentModel> ReadDataById(Guid StudentId);

        void AddNewData(StudentModel student);

        bool UpdateData(StudentModel student);

        bool DeleteData(Guid StudentId);
    }
}
