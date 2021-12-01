// See https://aka.ms/new-console-template for more information
using UserDefinedDataType;

    Student[] studentarray = null;
    int size = 0;

for (; ; )
{
    Console.WriteLine("1. Enter Student Details.");
    Console.WriteLine("2. Display Student Details.");
    String input = Console.ReadLine();
    if (input == "1")
    {
        Console.WriteLine("Enter the number of students:");

        int i = Convert.ToInt32(Console.ReadLine());
        size = i;
        studentarray = new Student[] { };

        if (i != 0)
        {
            for (int j = 0; j < i; j++)
            {

                Student student = new Student();
                Console.WriteLine($"Enter details for student{j + 1}");

                Console.WriteLine("Enter First Name");
                student.FirstName = Console.ReadLine();

                Console.WriteLine("Enter LastName");
                student.LastName = Console.ReadLine();

                Console.WriteLine("Enter Roll Number");
                student.Roll = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Marks Secured");
                student.MarksSecured = Convert.ToDouble(Console.ReadLine());

                studentarray = studentarray.Append(student).ToArray();
            }
        }

    }

    else if (input == "2")
    {

        Console.WriteLine("Thank You for sharing your Information. Your Details are as follows:");
        for (int i = 0; i < size; i++)
        {
            Student student = studentarray[i];
            Console.WriteLine($"FirstName: {student.FirstName}");
            Console.WriteLine($"LastName: {student.LastName}");
            Console.WriteLine($"Roll Number: {student.Roll}");
            Console.WriteLine($"Marks Secured: {student.MarksSecured}");
        }
    }
    else
    {
        Console.WriteLine("Invalid Input");
        break;
    }
    }


