using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace PraksaWebApi.Controllers
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public string birthday { get; set; }

    }

    public class StudentController : ApiController
    {
        public List<string> StudentList = new List<string>();

        [HttpGet]
        [Route("api/read")]
        public HttpResponseMessage ReadOrderData()
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string queryString =
                "SELECT ime,prezime,datum_rodjenja FROM STUDENT;";

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    StudentList.Add(ReadSingleRow((IDataRecord)reader));
                }

                // Call Close when done reading.
                reader.Close();

                return Request.CreateResponse(HttpStatusCode.OK, StudentList);
            }
        }

        [HttpGet]
        [Route("api/readbyid/{id}")]
        public HttpResponseMessage ReadOrderDataById(int id)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string queryString =
                "SELECT ime,prezime,datum_rodjenja FROM STUDENT WHERE (id = '" + id + "');";
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    StudentList.Add(ReadSingleRow((IDataRecord)reader));
                }

                // Call Close when done reading.
                reader.Close();
                
                if (StudentList.Count() == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, StudentList);
                }
                return Request.CreateResponse(HttpStatusCode.Found, StudentList); 
            }
        }

        public String ReadSingleRow(IDataRecord record)
        {
            return String.Format("{0}, {1}, {2}", record[0], record[1], record[2]);
        }

        [HttpPost]
        [Route("api/newstudent")]
        public HttpResponseMessage AddNewStudent([FromBody] Student s)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string queryString =
                "INSERT INTO STUDENT (id, ime, prezime, datum_rodjenja) VALUES ('" + s.id + "' ,'" + s.name+ "' ,'" + s.surname + "' ,'" 
                + s.birthday + "');";
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpPut]
        [Route("api/updatestudent")]
        public HttpResponseMessage UpdateStudent([FromBody] Student s)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string queryString =
                "UPDATE STUDENT SET ime = '" + s.name + "', prezime = '" +s.surname + "', datum_rodjenja = '" +
                s.birthday + "' WHERE id = '" + s.id + "';";
;
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpDelete]
        [Route("api/deletestudent/{id}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string queryString =
                " DELETE FROM INDEKS WHERE id = '" + id + "'; " +
                "DELETE FROM KOLEGIJ_STUDENT WHERE student_id = '" + id + "'; " +
                "DELETE FROM STUDENT WHERE id = '" + id + "';"; 
            ;
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }

}
