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
        Task<List<StudentModel>> ReadStudentsAsync(StudentFilter filter);

        Task<List<StudentModel>> ReadStudentByIdAsync(StudentPage page);

        Task AddNewStudentAsync(StudentModel student);

        Task<bool> UpdateStudentAsync(StudentModel student);

        Task<bool> DeleteStudentAsync(Guid StudentId);
    }
}
