using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.BO;

namespace EntityFramework.DAL
{
    public interface IStudentDAL
    {
        bool CreateStudent(Student student);
        bool CreateStudentWithSP(Student student);
        bool DeleteStudent(int rollNumber);
        Student GetStudentByRollNumber(int rollNo);
        List<Student> GetStudents();
        bool UpdateStudent(Student student);
    }
}
