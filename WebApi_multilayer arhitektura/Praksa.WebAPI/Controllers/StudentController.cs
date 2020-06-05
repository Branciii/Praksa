using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using PraksaWebApi.Models;
using ProjectService;
using ProjectModel;
using AutoMapper;

namespace Praksa.WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        public List<StudentModel> StudentList = new List<StudentModel>();
        public List<Student> Students = new List<Student>();
        ProjectService.StudentService studentServis = new ProjectService.StudentService();

        [HttpGet]
        [Route("api/read")]
        public HttpResponseMessage ReadStudentData()
        {
            StudentList = studentServis.ReadData();

            if (StudentList.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentModel, Student>();
            });
            IMapper iMapper = config.CreateMapper();

            foreach (StudentModel studentModel in StudentList)
            {
                Student student = iMapper.Map<StudentModel, Student>(studentModel);
                Students.Add(student);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Students);
        }


        [HttpGet]
        [Route("api/readbyid/{StudentId}")]
        public HttpResponseMessage ReadStudentDataById(Guid StudentId)
        {
            StudentList = studentServis.ReadDataById(StudentId);
            if (StudentList.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Found, StudentList);
        }


        [HttpPost]
        [Route("api/newstudent")]
        public HttpResponseMessage CreateNewStudent([FromBody] Student student)
        {
            if (!(student.IsValid()))
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed);
            }
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentModel>();
            });
            IMapper iMapper = config.CreateMapper();
            var studentModel = iMapper.Map<Student, StudentModel>(student);
            Guid obj = Guid.NewGuid();
            studentModel.id = obj;
            studentServis.AddNewData(studentModel);

            return Request.CreateResponse(HttpStatusCode.OK);

        }


        [HttpPut]
        [Route("api/updatestudent")]
        public HttpResponseMessage UpdateOneStudent([FromBody] StudentModel studentModel)
        {
            bool checkId = studentServis.UpdateData(studentModel);
            if (checkId == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        [Route("api/deletestudent/{StudentId}")]
        public HttpResponseMessage DeleteStudentById(Guid StudentId)
        {
            bool checkId  = studentServis.DeleteData(StudentId);
            if (checkId == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
