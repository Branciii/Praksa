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
        Task<List<StudentModel>> ReadDataAsync();

        Task<List<StudentModel>> ReadDataByIdAsync(Guid StudentId);

        Task AddNewDataAsync(StudentModel student);

        Task<bool> UpdateDataAsync(StudentModel student);

        Task<bool> DeleteDataAsync(Guid StudentId);
    }
}
