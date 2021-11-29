// See https://aka.ms/new-console-template for more information
using HelloWorld2;

Console.WriteLine("Hello, World!");
Calculator2 calc = new Calculator2();
calc.x = 10;
calc.y = 20;
int result = calc.Add();
Console.WriteLine(result);
