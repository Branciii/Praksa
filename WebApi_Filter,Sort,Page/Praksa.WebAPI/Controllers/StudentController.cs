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
using NLog.Filters;
using Praksa.Common;

namespace Praksa.WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        public List<StudentModel> StudentList = new List<StudentModel>();
        public List<Student> Students = new List<Student>();


        public StudentController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }
        protected IStudentService studentService { get; private set; }
        protected IMapper mapper { get; private set; }

        [HttpGet]
        [Route("api/readstudents")]
        public async Task<HttpResponseMessage> GetStudentsAsync([FromUri] StudentPage page)
        {
            StudentList = await studentService.ReadDataByIdAsync(page);

            if (StudentList.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            Students = mapper.Map<List<Student>>(StudentList);
            return Request.CreateResponse(HttpStatusCode.OK, Students);
        }

        /*
        [HttpGet]
        [Route("api/readstudents")]
        public async Task<HttpResponseMessage> GetStudentsAsync([FromBody] StudentFilter filter)
        {
            StudentList = await studentService.ReadDataAsync(filter);

            if (StudentList.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            Students = mapper.Map<List<Student>>(StudentList);
            return Request.CreateResponse(HttpStatusCode.OK, Students);
        }*/

        /*
        [HttpGet]
        [Route("api/readbyid/{StudentId}")]
        public async Task<HttpResponseMessage> ReadStudentDataByIdAsync(Guid StudentId)
        {
            StudentList = await studentService.ReadDataByIdAsync(StudentId);
            if (StudentList.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Found, StudentList);
        }*/


        [HttpPost]
        [Route("api/newstudent")]
        public async Task<HttpResponseMessage> CreateNewStudentAsync([FromBody] Student student)
        {
            if (!(student.IsValid()))
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed);
            }
            StudentModel studentModel = mapper.Map<StudentModel>(student);
            Guid obj = Guid.NewGuid();
            studentModel.id = obj;
            await studentService.AddNewDataAsync(studentModel);

            return Request.CreateResponse(HttpStatusCode.OK);

        }


        [HttpPut]
        [Route("api/updatestudent")]
        public async Task<HttpResponseMessage> UpdateOneStudentAsync([FromBody] StudentModel studentModel)
        {
            bool checkId = await studentService.UpdateDataAsync(studentModel);
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
            bool checkId  = await studentService.DeleteDataAsync(StudentId);
            if (checkId == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
