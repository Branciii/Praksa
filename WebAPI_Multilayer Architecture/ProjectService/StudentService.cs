using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRepository;
using ProjectModel;

namespace ProjectService
{
    public class StudentService
    {
        public List<StudentModel> StudentList = new List<StudentModel>();
        ProjectRepository.StudentRepository studentRepository = new ProjectRepository.StudentRepository();

        public StudentService() { }

        public List<StudentModel> ReadData()
        {
            StudentList = studentRepository.ReadStudents();
            return StudentList;
        }

        public List<StudentModel> ReadDataById(int id)
        {
            StudentList = studentRepository.ReadStudentById(id);
            return StudentList;
        }

        public void AddNewData(StudentModel s)
        {
            studentRepository.AddNewStudent(s);
        }

        public void UpdateData(StudentModel s)
        {
            studentRepository.UpdateStudent(s);
        }

        public void DeleteData(int id)
        {
            studentRepository.DeleteStudent(id);
        }
    }
}
