// See https://aka.ms/new-console-template for more information
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

Console.WriteLine("Hello, World!");

var apiClient=new ApiClient("https://localhost:7161/");
var apiInstance=new StudentsApi(apiClient);
for (; ; )
{
    Console.WriteLine("1.Get All Student Details.");
    Console.WriteLine("2. Find a Student by ID..");
    Console.WriteLine("3. Edit a Student by ID.");
    Console.WriteLine("4. Create Student");
    Console.WriteLine("5. Delete a Student by ID.");

    string input = Console.ReadLine();
    if (input == "1") //list of all students
    {
        try
        {
            List<StudentBO> result = apiInstance.ApiStudentsGetAllStudentsGet();
            foreach (var st in result)
            {


                Console.WriteLine($"FirstName: {st.FirstName}");
                Console.WriteLine($"LastName: {st.LastName}");
                Console.WriteLine($"Roll Number: {st.RollNo}");
                Console.WriteLine($"Marks Secured: {st.Marks}");
                //Console.WriteLine($"Branch:{st.Branch}");

            }
           // Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("+Exception when calling StuudentApi.ApiStudentsGetAllStudentsGet: " + ex.Message);
        }
    }
    else if (input == "2") //find student by id
    {
        try
        {
            Console.WriteLine("Enter the ID Number of the student you want to find.");
            var id = Convert.ToInt32(Console.ReadLine());
            var student = apiInstance.ApiStudentsGetStudentByIdGet(id);
            Console.WriteLine($"First Name :{student?.FirstName}");
            Console.WriteLine($"Last Name :{student?.LastName}");
           
            //Console.WriteLine($"Branch: :{student?.BranchName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("+Exception when calling StuudentApi.ApiStudentsGetStudentByIdGet: " + ex.Message);
        }
    }
    else if (input == "3" ) //update student
    {
        try {
            Console.WriteLine("Enter the ID Number of the student you want to edit.");
           
            var student = apiInstance.ApiStudentsGetStudentByIdGet(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"Firstname :{student?.FirstName}");
            Console.WriteLine($"Lastname :{student?.LastName}");

            //Console.WriteLine($"Roll Number :{student?.RollNo}");
            //Console.WriteLine($"Marks Secured :{student?.Marks}");

            Console.WriteLine("Enter The new marks of the student");//input for marks
            var newmarks = Convert.ToDouble(Console.ReadLine());
            student.Marks = newmarks;

            string es = apiInstance.ApiStudentsEditStudentPost(student);
           // apiInstance.ApiStudentsEditStudentPost(student);
           
        }
        catch(Exception ex) 
        {
            Console.WriteLine("Exception when calling StuudentApi.ApiStudentsEditStudentPost: " + ex.Message);
        }
    }
    else if (input == "4") //find student by id
    {
        try
        {
            Console.WriteLine("Enter the number of students:");

            int i = Convert.ToInt32(Console.ReadLine());
            var size = i;

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
                    student.RollNo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Marks Secured");
                    student.Marks = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter Branch");
                    student.Branch = Console.ReadLine();

                    //studentlist.Add(student);
                    string s = apiInstance.ApiStudentsCreateStudentPost(student);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("+Exception when calling StuudentApi.ApiStudentsGetStudentByIdGet: " + ex.Message);
        }
    }
    else if (input == "5") //find student by id
    {
        try
        {
            Console.WriteLine("Enter the id student you want to delete:");

            int id = Convert.ToInt32(Console.ReadLine());
            

            if (id != 0)
            {
               string s= apiInstance.ApiStudentsDeleteStudentByIdDelete(id);
                Console.WriteLine(s);

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("+Exception when calling StudentApi.ApiStudentsDeleteStudentByIdDelete: " + ex.Message);
        }
    }



}