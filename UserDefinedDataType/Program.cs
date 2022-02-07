﻿// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
//using UserDefinedDataType.BO;
using UserDefinedDataType.DAL;
using UserDefinedDataType;

var dal = new StudentDAL();
var studentlist=new List <Student>();
studentlist = dal.GetStudents();
/*dal.CreateStudentWithSP(new Student
{
    FirstName ="Ranen",
    LastName ="Ghosh",
    Roll=26,
    MarksSecured=99.88,
});
var s = dal.GetStudentByRollNumber(1);
var x = dal.UpdateStudent(new Student
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
            for(int j=0; j<i;j++ )
            {

                var student = new Student();
                Console.WriteLine($"Enter details for student{j+1}");

                Console.WriteLine("Enter First Name");
                student.FirstName = Console.ReadLine();

                Console.WriteLine("Enter LastName");
                student.LastName = Console.ReadLine();

                Console.WriteLine("Enter Roll Number");
                student.Roll = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Marks Secured");
                student.MarksSecured = Convert.ToDecimal(Console.ReadLine()); 

                studentlist.Add(student);
                var x = dal.CreateStudent(student);
            }
            
        }

    }

    else if (input == "2")
    {
        int count= dal.GetStudentCount();
        Console.WriteLine("Thank You for sharing your Information. Your Details are as follows:");
        for (int i = 0; i < count; i++)
        {
            
                Student student = studentlist[i];
                Console.WriteLine($"FirstName: {student.FirstName}");
                Console.WriteLine($"LastName: {student.LastName}");
                Console.WriteLine($"Roll Number: {student.Roll}");
                Console.WriteLine($"Marks Secured: {student.MarksSecured}");
            
        }
    }
    else if (input == "3")
    {
        Console.WriteLine("Enter the First Name of the sutend you want to find.");
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
        var name = student1.FirstName +" "+ student1.LastName;
        var marks= student1.MarksSecured;
        Console.WriteLine(name);
        Console.WriteLine("Marks Secured: ");Console.WriteLine(marks);

    }
    else if(input == "5")
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
   
   


