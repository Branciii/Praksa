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
using Praksa.Repository.Common;
using Praksa.Common;

namespace ProjectRepository
{
    public class StudentRepository : IStudentRepository
    {
        public List<StudentModel> StudentList = new List<StudentModel>();

        public async Task<List<StudentModel>> ReadStudentsAsync(StudentFilter filter)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string queryString =
                "SELECT id,ime,prezime FROM STUDENT ";

            if (filter.StudentHasName()||filter.StudentHasSurname())
            {
                queryString += "WHERE ";

                if (filter.StudentHasName())
                {
                    queryString += "(ime = '" + filter.StudentName + "')";

                    if (filter.StudentHasSurname())
                    {
                        queryString += " AND (prezime = '" + filter.StudentSurname + "')";
                    }
                }
                else
                {
                    queryString += "(prezime = '" + filter.StudentSurname + "')";
                }
            }
            queryString += ";";

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = await Task.Run(()=>command.ExecuteReader());
                
                // Call Read before accessing data.
                while (reader.Read())
                {
                    StudentList.Add(new StudentModel { id = reader.GetGuid(0), name = reader.GetString(1), surname = reader.GetString(2) });
                }

                // Call Close when done reading.
                reader.Close();
            }
            return StudentList;
        }

        public async Task<List<StudentModel>> ReadStudentByIdAsync(Guid StudentId)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string queryString =
                "SELECT id,ime,prezime FROM STUDENT WHERE (id = '" + StudentId + "');";
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = await Task.Run(() => command.ExecuteReader());

                // Call Read before accessing data.
                while (reader.Read())
                {
                    StudentList.Add(new StudentModel { id = reader.GetGuid(0), name = reader.GetString(1), surname = reader.GetString(2) });
                }

                // Call Close when done reading.
                reader.Close();

                return StudentList;
            }
        }

        public async Task AddNewStudentAsync(StudentModel student)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PraksaSQL;Integrated Security=True";
            string queryString =
                "INSERT INTO STUDENT (id, ime, prezime) VALUES ('" + student.id + "' ,'" + student.name + "' ,'" + student.surname + "');";
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = await Task.Run(() => command.ExecuteReader());

            }
        }

        public async Task<bool> UpdateStudentAsync(StudentModel student)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string checkIdExistence =
                "SELECT COUNT(*) as count FROM STUDENT WHERE id = '" + student.id + "';";
            ;
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(checkIdExistence, connection);
                connection.Open();

                int userCount = await Task.Run(()=>(int)command.ExecuteScalar());
                if (userCount == 0)
                {
                    return false;
                }

                string queryString =
                "UPDATE STUDENT SET ime = '" + student.name + "', prezime = '" + student.surname + "' WHERE id = '" + student.id + "';";

                command =
                    new SqlCommand(queryString, connection);

                SqlDataReader reader = await Task.Run(() => command.ExecuteReader());

                reader.Close();
            }
            return true;
            
        }

        public async Task<bool> DeleteStudentAsync(Guid StudentId)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = PraksaSQL; Integrated Security = True";

            string checkIdExistence =
                "SELECT COUNT(*) as count FROM STUDENT WHERE id = '" + StudentId + "';";
            ;
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(checkIdExistence, connection);
                connection.Open();

                int userCount = (int)command.ExecuteScalar();
                if (userCount == 0)
                {
                    return false;
                }
                string queryString =
                " DELETE FROM INDEKS WHERE id = '" + StudentId + "'; " +
                "DELETE FROM KOLEGIJ_STUDENT WHERE student_id = '" + StudentId + "'; " +
                "DELETE FROM STUDENT WHERE id = '" + StudentId + "';";

                SqlDataReader reader = await Task.Run(() => command.ExecuteReader());
                return true;
            }
        }

    }
}
