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

        public List<StudentModel> ReadData()
        {
            StudentList = studentRepository.ReadStudents();
            return StudentList;
        }

        public List<StudentModel> ReadDataById(Guid StudentId)
        {
            StudentList = studentRepository.ReadStudentById(StudentId);
            return StudentList;
        }

        public void AddNewData(StudentModel student)
        {
            studentRepository.AddNewStudent(student);
        }

        public bool UpdateData(StudentModel student)
        {
            return(studentRepository.UpdateStudent(student));
        }

        public bool DeleteData(Guid StudentId)
        {
            return (studentRepository.DeleteStudent(StudentId));
        }
    }
}
