using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectModel;
using Praksa.Common;

namespace Praksa.Service.Common
{
    public interface IStudentService
    {
        Task<List<StudentModel>> ReadDataAsync(StudentFilter filter);

        Task<List<StudentModel>> ReadDataByIdAsync(StudentPage page);

        Task AddNewDataAsync(StudentModel student);

        Task<bool> UpdateDataAsync(StudentModel student);

        Task<bool> DeleteDataAsync(Guid StudentId);
    }
}
