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
        Task<List<StudentModel>> ReadStudentsAsync();

        Task<List<StudentModel>> ReadStudentByIdAsync(Guid StudentId);

        Task AddNewStudentAsync(StudentModel student);

        Task<bool> UpdateStudentAsync(StudentModel student);

        Task<bool> DeleteStudentAsync(Guid StudentId);
    }
}
