// See https://aka.ms/new-console-template for more information
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

Console.WriteLine("Hello, World!");
var apiClient = new ApiClient("https://localhost:7161/");
var apiInstance = new StudentsApi(apiClient);

try
{
    List<StudentBO> result = apiInstance.ApiStudentsGetAllStudentsGet();
    Console.WriteLine(result);

    var student = apiInstance.ApiStudentsGetStudentByIdGet(1);
    Console.WriteLine(student?.FirstName);

}
catch (Exception e)
{
    Console.WriteLine("Exception when calling AspDotNetCoreWebApi.ConsoleAppWebApiGetAllStudentsGet: " + e.Message);


}