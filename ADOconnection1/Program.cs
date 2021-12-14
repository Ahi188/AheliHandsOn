// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
namespace ConnectingToSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a connection string and store it in a variable
            string connectionString = "Data Source=LAPTOP-IG3PIKP2;Initial Catalog=1st Database; Integrated Security=SSPI; TrustServerCertificate=true;";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "Select * from Student1";
                    var dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        string firstName=dr["First_Name"].ToString();
                        string lastName =dr["Last_Name"].ToString();
                        string rollnumber = dr["Roll_number"].ToString();
                        string marks = dr["Marks"].ToString();

                        Console.WriteLine(firstName+" "+lastName+" "+rollnumber+" "+marks);
                    }
                    dr.Close();
                }
            }
            Console.ReadKey();
        }
    }
}