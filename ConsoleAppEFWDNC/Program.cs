using ConsoleAppEFWDNC.DB;
using ConsoleAppEFWDNC.DAL;
using ConsoleAppEFWDNC.BO;

namespace ConsoleAppEFWDNC
{
    class Program
    {
        static void Main(string[] args) 
     {
            var dal = new StudentDAL();
            /*dal.UpdateStudent(new StudentBO
            {
                FirstName ="IfIwere",
                LastName ="aMAN",
                Roll=100,
                MarksSecured=100
            });
            dal.DeleteStudent(100);*/
            var studentlist = new List<BO.StudentBO>();
            /*studentlist = dal.GetStudents();
            dal.CreateStudentWithSP(new StudentBO
            {
                FirstName ="Ranen",
                LastName ="Ghosh",
                Roll=26,
                MarksSecured=99,
            });
            var s = dal.GetStudentByRollNumber(1);
            var x = dal.UpdateStudent(new StudentBO
            {
                FirstName = "Aparna",
                LastName = "Roy",
                Roll = 27,
                MarksSecured = 100
            });*/

           int size = 0;

            for (; ; )
            {
                Console.WriteLine("1. Enter Student Details.");
                Console.WriteLine("2. Display Student Details.");
                Console.WriteLine("3. Find a Student by Name.");
                Console.WriteLine("4. Find a Student by Roll.");
                Console.WriteLine("5. Change the Last-Name of all Students");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Enter the number of students:");

                    int i = Convert.ToInt32(Console.ReadLine());
                    size = i;

                    if (i != 0)
                    {
                        //for loop
                        for (int j = 0; j < i; j++)
                        {

                            var student = new StudentBO();
                            Console.WriteLine($"Enter details for student{j + 1}");

                            Console.WriteLine("Enter First Name");
                            student.FirstName = Console.ReadLine();

                            Console.WriteLine("Enter LastName");
                            student.LastName = Console.ReadLine();

                            Console.WriteLine("Enter Roll Number");
                            student.Roll = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Marks Secured");
                            student.MarksSecured = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("Enter Branch");
                            student.Branch = Console.ReadLine();

                            studentlist.Add(student);
                            var x = dal.CreateStudent(student);
                        }

                    }

                }

                else if (input == "2")
                {
                    studentlist = dal.GetStudents();
                    Console.WriteLine("Thank You for sharing your Information. Your Details are as follows:");
                    foreach (var st in studentlist)
                    {


                        Console.WriteLine($"FirstName: {st.FirstName}");
                        Console.WriteLine($"LastName: {st.LastName}");
                        Console.WriteLine($"Roll Number: {st.Roll}");
                        Console.WriteLine($"Marks Secured: {st.MarksSecured}");
                        //Console.WriteLine($"Branch:{st.Branch}");

                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("Enter the First Name of the student you want to find.");
                    var firstname = Console.ReadLine();
                    var person = studentlist.Where(x => x.FirstName == firstname).FirstOrDefault();
                    Console.WriteLine("Latst name : "); Console.WriteLine(person.LastName);
                    Console.WriteLine("Roll Number: "); Console.WriteLine(person.Roll);
                }

                else if (input == "4")
                {
                    Console.WriteLine("Enter the Roll Number of the Student you want to find");
                    var rollNo = Convert.ToInt32(Console.ReadLine());
                    var student1 = studentlist.Where(x => x.Roll == rollNo).FirstOrDefault(); //Find a particular student
                    var name = student1.FirstName + " " + student1.LastName;
                    var marks = student1.MarksSecured;
                    Console.WriteLine(name);
                    Console.WriteLine("Marks Secured: "); Console.WriteLine(marks);

                }
                else if (input == "5")
                {
                    Console.WriteLine("Changed the Last Name");
                    foreach (var item in studentlist) // foreach (Student item in studentlist)
                    {
                        // execute code
                        item.LastName = "TCS"; // lastname of every student will be changed. 
                        var name1 = item.FirstName + " " + item.LastName;
                        Console.WriteLine(name1);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    break;
                }
            }
        }
    }
}