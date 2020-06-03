using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PraksaWebApi.Controllers
{

    public class Student
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class StudentController : ApiController
    {
        public List<Student> StudentList = new List<Student>();

        [HttpGet]
        [Route("api/see/students")]

        public HttpResponseMessage SeeAllStudents()
        {
            if (StudentList.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, StudentList);
        }

        [HttpPost]
        [Route("api/new/student")]
        public List<Student> AddNewList([FromBody] Student obj)
        {

            StudentList.Add(new Student
            {
                Id = obj.Id,
                FirstName = obj.FirstName,
                LastName = obj.LastName
            });
            return StudentList;

        }

        /*
        [HttpPut]
        [Route("api/update")]
        */

        [HttpDelete]
        [Route("api/delete")]
        public HttpResponseMessage DeleteAllStudents()
        {
            if (StudentList.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            StudentList.Clear();
            return Request.CreateResponse(HttpStatusCode.OK, StudentList);
        }


    }
}
