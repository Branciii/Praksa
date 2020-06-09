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
using System.Threading.Tasks;
using Praksa.Service.Common;

namespace Praksa.WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        public List<StudentModel> StudentList = new List<StudentModel>();
        public List<Student> Students = new List<Student>();
 
        public StudentController(IStudentService service)
        {
            this.studentServis = service;
        }
        protected IStudentService studentServis { get; private set; }




        [HttpGet]
        [Route("api/read")]
        public async Task<HttpResponseMessage> ReadStudentDataAsync()
        {
            StudentList = await studentServis.ReadDataAsync();

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
        public async Task<HttpResponseMessage> ReadStudentDataByIdAsync(Guid StudentId)
        {
            StudentList = await studentServis.ReadDataByIdAsync(StudentId);
            if (StudentList.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Found, StudentList);
        }


        [HttpPost]
        [Route("api/newstudent")]
        public async Task<HttpResponseMessage> CreateNewStudentAsync([FromBody] Student student)
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
            await studentServis.AddNewDataAsync(studentModel);

            return Request.CreateResponse(HttpStatusCode.OK);

        }


        [HttpPut]
        [Route("api/updatestudent")]
        public async Task<HttpResponseMessage> UpdateOneStudentAsync([FromBody] StudentModel studentModel)
        {
            bool checkId = await studentServis.UpdateDataAsync(studentModel);
            if (checkId == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        [Route("api/deletestudent/{StudentId}")]
        public async Task<HttpResponseMessage> DeleteStudentByIdAsync(Guid StudentId)
        {
            bool checkId  = await studentServis.DeleteDataAsync(StudentId);
            if (checkId == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
