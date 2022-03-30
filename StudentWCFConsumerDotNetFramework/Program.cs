using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentWCFConsumerDotNetFramework.StudentServiceReference;

namespace StudentWCFConsumerDotNetFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 0;

            for (; ; )
            {
                Console.WriteLine("1. Create Student.");
                Console.WriteLine("2. Update Student Details.");
                Console.WriteLine("3. Delete a Student by Roll.");
                

                string input = Console.ReadLine();
                if (input == "1")
                {
                    var service = new StudentServiceClient();
                    var header = new HeaderInfo
                    {
                        TransactionID = Guid.NewGuid().ToString()
                    };
                    var body = new StudentBO
                    {
                        FirstName = "Aheliiii",
                        LastName = "Ghoshhh",
                        Roll_number = 12345,
                        Marks = 12345
                    };
                    service.CreateStudent(ref header, body);
                    Console.WriteLine(header.TransactionID);
                    Console.WriteLine(header.CallStatus);
                    Console.ReadKey();
                }
                //UPDATE METHOD
                else if (input == "2")
                {
                    Console.WriteLine("Enter the changed First Name of the student:");
                    var FN = Console.ReadLine();
                    Console.WriteLine("Enter the changed Last Name oof the student:");
                    var LN = Console.ReadLine();
                    Console.WriteLine("Enter the changed Roll Number of the student:");
                    var Roll = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the changed Marks :");
                    var M = Convert.ToInt32(Console.ReadLine());
                    var service = new StudentServiceClient();
                    var header = new HeaderInfo
                    {
                        TransactionID = Guid.NewGuid().ToString()
                    };
                    var body = new StudentBO
                    {
                        FirstName = FN,
                        LastName = LN,
                        Roll_number = Roll,
                        Marks = M,
                    };

                    service.UpdateStudent(ref header, body);
                    Console.WriteLine(header.TransactionID);
                    Console.WriteLine(header.CallStatus);
                    Console.ReadKey();

                }

                //DELETE METHOD
                else if (input == "3")
                {

                  
                    var service = new StudentServiceClient();
                    var header = new HeaderInfo
                    {
                        TransactionID = Guid.NewGuid().ToString()
                    };
                    
                    Console.WriteLine("Enter the changed Roll Number of the student:");
                    var Roll = Convert.ToInt32(Console.ReadLine());
                   
                    var body = new StudentBO
                    {
                       
                        Roll_number = Roll,
                       

                    };
                    service.DeleteStudent(ref header, body);
                    Console.WriteLine(header.TransactionID);
                    Console.WriteLine(header.CallStatus);
                    Console.ReadKey();

                }
            }
        }
    }
}

