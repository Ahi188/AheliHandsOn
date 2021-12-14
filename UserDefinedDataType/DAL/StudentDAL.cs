using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDefinedDataType.DAL
{
    public class StudentDAL
    {
        private readonly string _connectionString;
        public StudentDAL()
        {
            /* ConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json")
             .Build();
             _connectionString = configuration.GetConnectionString("1st Database");*/

            _connectionString = "Data Source= LAPTOP-IG3PIKP2;Initial Catalog=1st Database;Integrated Security=True;TrustServerCertificate=True";
        }
            public List<Student> GetStudents()
            {
                var studentList = new List<Student>();
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string str = "select * from Student1";
                    using (SqlCommand command = new SqlCommand(str, sqlConnection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var student = new Student();
                            student.FirstName = reader["First_Name"] as string;
                            student.LastName = reader["Last_Name"] as string;
                            student.Roll = reader["Roll_number"] as int?;
                            student.MarksSecured = reader["Marks"] as double?;
                            studentList.Add(student);
                        }

                        reader.Close();
                        sqlConnection.Close();
                    }
                }
                return studentList;
            }

            public Student GetStudentByRollNumber(int rollNo)
            {
                var student = new Student();
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string str = "select * from Student1 where Roll_number=@rollNo";

                    using (SqlCommand command = new SqlCommand(str, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@rollNo", rollNo);
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            student.FirstName = reader["First_name"] as string;
                            student.LastName = reader["Last_name"] as string;
                            student.Roll = reader["Roll_number"] as int?;
                            student.MarksSecured = reader["Marks"] as double?;
                        }

                        reader.Close();
                        sqlConnection.Close();
                    }
                }
                return student;
            }

            public bool CreateStudent(Student student)
            {
                bool isSuccess = true;
                try
                {

                    using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                    {
                        sqlConnection.Open();
                    string str = "INSERT INTO Student1 (First_Name, Last_name,Roll_number,Marks) VALUES (@firstName,@lastName,@rollNo,@marks);"
                                + "SET @Id=SCOPE_IDENTITY();";
                    int? id = 0;
                        var sqlParamId = new SqlParameter { Direction = System.Data.ParameterDirection.Output, ParameterName = "@Id", DbType = System.Data.DbType.Int32 };


                        using (SqlCommand command = new SqlCommand(str, sqlConnection))
                        {
                            command.Parameters.AddWithValue("@firstName", student.FirstName);
                            command.Parameters.AddWithValue("@lastName", student.LastName);
                            command.Parameters.AddWithValue("@rollNo", student.Roll);
                            command.Parameters.AddWithValue("@marks", student.MarksSecured);
                            command.Parameters.Add(sqlParamId);
                            var result = command.ExecuteNonQuery();
                            id = sqlParamId.Value as int?;
                            sqlConnection.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    isSuccess = false;
                    Console.WriteLine("An error occurred. " + e.Message);
                    throw;
                }
                return isSuccess;
            }

            public bool CreateStudentWithSP(Student student)
            {
                bool isSuccess = true;
                try
                {

                    using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                    {
                        sqlConnection.Open();
                        string str = "CreateStudent";
                        using (SqlCommand command = new SqlCommand(str, sqlConnection))
                        {
                            command.CommandType = System.Data.CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@firstName", student.FirstName);
                            command.Parameters.AddWithValue("@lastName", student.LastName);
                            command.Parameters.AddWithValue("@rollNo", student.Roll);
                            command.Parameters.AddWithValue("@marks", student.MarksSecured);
                            var result = command.ExecuteScalar();
                            sqlConnection.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    isSuccess = false;
                    Console.WriteLine("An error occurred. " + e.Message);
                    throw;
                }
                return isSuccess;
            }

            public bool UpdateStudent(Student student)
            {
                bool isSuccess = true;
                try
                {

                    using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                    {
                        sqlConnection.Open();
                        string str = "UPDATE Student1 " +
                            "SET First_name=@firstName, " +
                                "Last_name=@lastName," +
                                "Marks=@marks " +
                             "WHERE Roll_number=@rollNo;";

                        using (SqlCommand command = new SqlCommand(str, sqlConnection))
                        {
                            command.Parameters.AddWithValue("@firstName", student.FirstName);
                            command.Parameters.AddWithValue("@lastName", student.LastName);
                            command.Parameters.AddWithValue("@rollNo", student.Roll);
                            command.Parameters.AddWithValue("@marks", student.MarksSecured);
                            var result = command.ExecuteNonQuery();
                            sqlConnection.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    isSuccess = false;
                    Console.WriteLine("An error occurred. " + e.Message);
                    throw;
                }
                return isSuccess;
            }

            public bool DeleteStudent(int rollNumber)
            {
                bool isSuccess = true;
                try
                {

                    using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                    {
                        sqlConnection.Open();
                        string str = "DELETE Student " + Environment.NewLine +
                             "WHERE Roll_number=@rollNo;";

                        using (SqlCommand command = new SqlCommand(str, sqlConnection))
                        {
                            command.Parameters.AddWithValue("@rollNo", rollNumber);
                            var result = command.ExecuteNonQuery();
                            sqlConnection.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    isSuccess = false;
                    Console.WriteLine("An error occurred. " + e.Message);
                    throw;
                }
                return isSuccess;
            }
        public int getStudentCount ()
        {
            return 36;
        }
        }
    }





