using WebAPI.BO;
namespace WebAPI.DAL
{
    public interface IStudentDAL
    {
       IEnumerable<StudentBO> GetStudents();
        StudentBO GetStudent(int id);
       bool CreateStudent(StudentBO student);
        bool EditStudent(StudentBO student);
        bool DeleteStudentById(int id);
    }
}
