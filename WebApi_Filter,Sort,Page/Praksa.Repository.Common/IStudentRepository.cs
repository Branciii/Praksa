using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectModel;
using Praksa.Common;

namespace Praksa.Repository.Common
{
    public interface IStudentRepository
    {

        Task<List<StudentModel>> ReadStudentAsync(StudentFilter filter, StudentSort sort, StudentPage page);

        Task AddNewStudentAsync(StudentModel student);

        Task<bool> UpdateStudentAsync(StudentModel student);

        Task<bool> DeleteStudentAsync(Guid StudentId);
    }
}
