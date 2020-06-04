using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Data.SqlClient;
using ProjectModel;

namespace ProjectRepository
{
    public class StudentRepository
    {
        public List<StudentModel> StudentList = new List<StudentModel>();
        public StudentRepository() { }

        public List<StudentModel> ReadStudents()
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string queryString =
                "SELECT id,ime,prezime FROM STUDENT;";

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
                    StudentList.Add(new StudentModel {id = reader.GetInt32(0), name = reader.GetString(1), surname = reader.GetString(2) });
                }

                // Call Close when done reading.
                reader.Close();

            }
            return StudentList;
        }

        public List<StudentModel> ReadStudentById(int id)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string queryString =
                "SELECT id,ime,prezime FROM STUDENT WHERE (id = '" + id + "');";
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
                    StudentList.Add(new StudentModel { id = reader.GetInt32(0), name = reader.GetString(1), surname = reader.GetString(2) });
                }

                // Call Close when done reading.
                reader.Close();

                return StudentList;
            }
        }

        public void AddNewStudent(StudentModel s)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";
            string queryString =
                "INSERT INTO STUDENT (id, ime, prezime) VALUES ('" + s.id + "' ,'" + s.name + "' ,'" + s.surname + "');";
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

            }
        }

        public void UpdateStudent(StudentModel s)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string queryString =
                "UPDATE STUDENT SET ime = '" + s.name + "', prezime = '" + s.surname + "' WHERE id = '" + s.id + "';";
            ;
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

            }
        }

        public void DeleteStudent(int id)
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

            }
        }
 
    }
}
