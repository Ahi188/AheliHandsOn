﻿// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

using UserDefinedDataType;

    List <Student> studentlist = null;
    int size = 0;

for (; ; )
{
    Console.WriteLine("1. Enter Student Details.");
    Console.WriteLine("2. Display Student Details.");
    Console.WriteLine("3. Find a Student by Name.");
    Console.WriteLine("4. Find a Student by Roll.");
    Console.WriteLine("5. Change the Last-Name of all Students");

    String input = Console.ReadLine();
    if (input == "1")
    {
        Console.WriteLine("Enter the number of students:");

        int i = Convert.ToInt32(Console.ReadLine());
        size = i;
        studentlist = new List<Student> { };
        int j = 1;

        if (i != 0)
        {
            //while loop
            do
            {

                Student student = new Student();
                Console.WriteLine($"Enter details for student{j}");

                Console.WriteLine("Enter First Name");
                student.FirstName = Console.ReadLine();

                Console.WriteLine("Enter LastName");
                student.LastName = Console.ReadLine();

                Console.WriteLine("Enter Roll Number");
                student.Roll = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Marks Secured");
                student.MarksSecured = Convert.ToDouble(Console.ReadLine());
                studentlist.Add(student);
                j++;

            } while (j <= i);
        }

    }

    else if (input == "2")
    {

        Console.WriteLine("Thank You for sharing your Information. Your Details are as follows:");
        for (int i = 0; i < size; i++)
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
        var name = student1.FirstName + student1.LastName;
        Console.WriteLine(name);

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
   
   
/*
static void main1()
{
    var length = 10;
    var i = 0;
    for (i = 0; i < length; i++)
    {
        //code exectution block
    }

    length = 5;
    



    while (i <= length)
    {
        // code execution block
        i++;
    }




    do
    {
        //code block
        i++;
    } while (i <= length);



    var studentlist = new List<Student>();
    foreach(var item in studentlist) // foreach (Student item in studentlist)
    {
        // execute code
        Console.WriteLine(item.FirstName);
        item.LastName = "Bla bla"; // lastname of  student will be changed. 
    }

    //Find specific student
    var rollNo=Convert.ToInt32(Console.ReadLine());
   var student = studentlist.Where(x => x.Roll == rollNo).FirstOrDefault();

    var firstname = Console.ReadLine();
    studentlist.Where(x => x.FirstName == firstname).FirstOrDefault();

    var students = studentlist.Where(x => x.FirstName == firstname).ToList; //for unique names ( doubt) 
}
*/
