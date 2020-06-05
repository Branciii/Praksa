using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectModel;

namespace Praksa.Repository.Common
{
    public interface IRepository
    {
        List<StudentModel> ReadStudents();

        List<StudentModel> ReadStudentById(Guid StudentId);

        void AddNewStudent(StudentModel student);

        bool UpdateStudent(StudentModel student);

        bool DeleteStudent(Guid StudentId);
    }
}
