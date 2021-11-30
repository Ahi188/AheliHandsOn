// See https://aka.ms/new-console-template for more information
using UserDefinedDataType;
for (int i = 0; i < 5; i++)
{
    Student student = new Student();

    Console.WriteLine("Please enter information about the student");
    Console.WriteLine("Enter First Name");
    student.FirstName = Console.ReadLine();

    Console.WriteLine("Enter LastName");
    student.LastName = Console.ReadLine();

    Console.WriteLine("Enter Roll Number");
    student.Roll = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Enter Marks Secured");
    student.MarksSecured = Convert.ToDouble(Console.ReadLine());
    
    Console.WriteLine("Thank You for sharing your Information. Your Details are as follows:");
    //printing
    Console.WriteLine($"FirstName: {student.FirstName}");
    Console.WriteLine($"LastName: {student.LastName}");
    Console.WriteLine($"Roll Number: {student.Roll}");
    Console.WriteLine($"Marks Secured: {student.MarksSecured}");
}
