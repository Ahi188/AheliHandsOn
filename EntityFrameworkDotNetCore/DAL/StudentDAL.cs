using EntityFrameworkDotNetCore.BO;
using EntityFrameworkDotNetCore.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDotNetCore.DAL
{
    public class StudentDAL 
    {
        private readonly TrainingDbContext _db;//wrapper of database
        public StudentDAL()
        {
            IConfigurationRoot configuration=new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DBConnectionString");
            var dbContextOptions = new DbContextOptionsBuilder<TrainingDbContext>().UseSqlServer(connectionString).Options;
            _db = new TrainingDbContext(dbContextOptions);
        }
        public bool CreateStudent(StudentBO student)
        {
            var success = true;
            try
            {
                var branch = student.Branch;
                int? branchId = null;
                if (!string.IsNullOrEmpty(branch))
                {
                    branchId = _db.Branch.Where(x => x.Name == branch).FirstOrDefault()?.Id;
                    if (branchId == null)
                    {
                        var createBranch = _db.Branch.Add(new Branch { Name = branch });
                        _db.SaveChanges();
                        branchId = createBranch.Entity.Id;
                    }
                }

                _db.Student1.Add(new Student1
                {
                    First_name = student.FirstName,
                    Last_name = student.LastName,
                    Roll_number = student.Roll,
                    Marks = student.MarksSecured,
                });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
                throw;
            }
            return success;
        }

        public bool CreateStudentWithSP(StudentBO student)
        {
            try
            {
                var result = _db.CreateStudent(student.FirstName, student.LastName, student.Roll, (decimal?)student.MarksSecured);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                return false;
            }
            return true;
        }

        public bool DeleteStudent(int rollNumber)
        {
            try
            {
                var students = _db.Student1.Where(x => x.Roll_number == rollNumber);
                _db.Student1.RemoveRange(students);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                return false;
            }
            return true;
        }

        public StudentBO GetStudentByRollNumber(int rollNo)
        {
            var student = _db.Student1.Where(r => r.Roll_number == rollNo).Select(x => new StudentBO
            {
                FirstName = x.First_name,
                LastName = x.Last_name,
                Roll = x.Roll_number,
                MarksSecured = x.Marks,
                Branch = x.Branch.Name
            }).FirstOrDefault();

            return student;
        }

        public List<StudentBO> GetStudents()
        {
            var list = _db.Student1.Select(x => new StudentBO
            {
                FirstName = x.First_name,
                LastName = x.Last_name,
                Roll = x.Roll_number,
                MarksSecured = x.Marks,
                Branch = x.First_name
            }).ToList();
            return list;
        }

        public bool UpdateStudent(StudentBO student)
        {
            try
            {
                var st = _db.Student1.Where(x => x.Roll_number == student.Roll).FirstOrDefault();
                st.First_name = student.FirstName;
                st.Last_name = student.LastName;
                st.Marks = (decimal?)student.MarksSecured;
                _db.Student1.Add(st);
                _db.Entry(st).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                return false;
            }
            return true;
        }
        /*public int GetStudentCount()
        {
           
        }*/

    }
}
