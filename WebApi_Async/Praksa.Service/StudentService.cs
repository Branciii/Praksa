using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRepository;
using ProjectModel;
using Praksa.Service.Common;

namespace ProjectService
{
    public class StudentService : IStudentService
    {
        public List<StudentModel> StudentList = new List<StudentModel>();
        ProjectRepository.StudentRepository studentRepository = new ProjectRepository.StudentRepository();

        public StudentService() { }

        public async Task<List<StudentModel>> ReadDataAsync()
        {
            StudentList = await studentRepository.ReadStudentsAsync();
            return StudentList;
        }

        public async Task<List<StudentModel>> ReadDataByIdAsync(Guid StudentId)
        {
            StudentList = await studentRepository.ReadStudentByIdAsync(StudentId);
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
