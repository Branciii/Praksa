using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRepository;
using ProjectModel;
using Praksa.Service.Common;
using Praksa.Repository.Common;
using Praksa.Common;

namespace ProjectService
{
    public class StudentService : IStudentService
    {
        public List<StudentModel> StudentList = new List<StudentModel>();
        protected IStudentRepository studentRepository { get; private set; }


        public StudentService(IStudentRepository studentRepository) 
        {
            this.studentRepository = studentRepository;
        }

        public async Task<List<StudentModel>> ReadDataAsync(StudentFilter filter, StudentSort sort, StudentPage page)
        {
            StudentList = await studentRepository.ReadStudentAsync(filter, sort, page);
            return StudentList;
        }

        public async Task AddNewDataAsync(StudentModel student)
        {
            await studentRepository.AddNewStudentAsync(student);
        }

        public async Task<bool> UpdateDataAsync(StudentModel student)
        {
            return(await studentRepository.UpdateStudentAsync(student));
        }

        public async Task<bool> DeleteDataAsync(Guid StudentId)
        {
            return (await studentRepository.DeleteStudentAsync(StudentId));
        }
    }
}
