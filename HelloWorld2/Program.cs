// See https://aka.ms/new-console-template for more information
using HelloWorld2;

Console.WriteLine("Hello, World!");
Calculator2 calc = new Calculator2();
calc.Number1 = 100;
calc.Number2 = 20;
int result1 = calc.Add();
int result2 = calc.Subtract();
Console.WriteLine(result1);
Console.WriteLine(result2);

