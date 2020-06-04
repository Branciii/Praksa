using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using PraksaWebApi.Models;
using Microsoft.Build.Evaluation;
using ProjectService;
using ProjectModel;

namespace PraksaWebApi.Controllers
{

    public class StudentController : ApiController
    {
        public List<StudentModel> StudentList = new List<StudentModel>();
        ProjectService.StudentService studentServis = new ProjectService.StudentService();

        [HttpGet]
        [Route("api/read")]
        public HttpResponseMessage ReadStudentData()
        {
            StudentList = studentServis.ReadData();
            return Request.CreateResponse(HttpStatusCode.OK, StudentList);
        }
        
        [HttpGet]
        [Route("api/readbyid/{id}")]
        public HttpResponseMessage ReadStudentDataById(int id)
        {
            StudentList = studentServis.ReadDataById(id);
            if (StudentList.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Found, StudentList);
        }


        [HttpPost]
        [Route("api/newstudent")]
        public HttpResponseMessage CreateNewStudent([FromBody] StudentModel s)
        {
            studentServis.AddNewData(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        
        [HttpPut]
        [Route("api/updatestudent")]
        public HttpResponseMessage UpdateOneStudent([FromBody] StudentModel s)
        {
            studentServis.UpdateData(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/deletestudent/{id}")]
        public HttpResponseMessage DeleteStudentById(int id)
        {
            studentServis.DeleteData(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
