using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApplicationDotNetCoreDateTime.BO;
using WebApplicationDotNetCoreDateTime.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace WebApplicationDotNetCoreDateTime.DAL

{
    public class StudentDAL
    {
        private readonly TrainingDbContext _db;//wrapper of database
        public StudentDAL()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
            var connectionString = configuration.GetConnectionString("DBConnectionString");
            var dbContextOptions = new DbContextOptionsBuilder<TrainingDbContext>().UseSqlServer(connectionString).Options;
            _db = new TrainingDbContext(dbContextOptions);
            //_db = new TrainingDbContext(dbContextOptions);
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
                    //First_name
                    FirstName= student.FirstName,
                    //Last_name
                    LastName= student.LastName,
                    //Roll_number 
                    RollNumber= student.Roll,
                    Marks = student.MarksSecured,
                    BranchId = branchId,
                    //Date_of_Birth
                    DateOfBirth = student.DateOfBirth,

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
                var result = _db.Database.ExecuteSqlInterpolated($"CreateStudent @firstname={student.FirstName},@lastname={student.LastName}, @rollno={student.Roll}, @marks={student.MarksSecured}");
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
                var students = _db.Student1.Where(x => x.RollNumber == rollNumber);
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
            var student = _db.Student1.Where(r => r.RollNumber == rollNo).Select(x => new StudentBO
            {
                Id = x.Id, //get the id
                FirstName = x.FirstName,
                LastName = x.LastName,
                Roll = x.RollNumber,
                MarksSecured = x.Marks,
                BranchId = x.Branch.Id,
                DateOfBirth = x.DateOfBirth,

            }).FirstOrDefault();

            return student;
        }
        public StudentBO GetStudentById(int id)
        {
            var student = _db.Student1.Where(r => r.Id == id).Select(x => new StudentBO
            {
                Id = x.Id, //get the id
                FirstName = x.FirstName,
                LastName = x.LastName,
                Roll = x.RollNumber,
                MarksSecured = x.Marks,
                BranchId = x.Branch.Id,
                Branch = x.Branch.Name,
                DateOfBirth = x.DateOfBirth,

            }).FirstOrDefault();
            return student;
        }

        public List<StudentBO> GetStudents()
        {
            var list = _db.Student1.Select(x => new StudentBO
            {
                Id = x.Id, //fetch the id
                FirstName = x.FirstName,
                LastName = x.LastName,
                Roll = x.RollNumber,
                MarksSecured = x.Marks,
                BranchId = x.Branch.Id,
                Branch = x.Branch.Name,
                DateOfBirth = x.DateOfBirth,
            }).ToList();
            return list;
        }

        public bool UpdateStudent(StudentBO student)
        {
            try
            {
                var st = _db.Student1.Where(x => x.RollNumber == student.Roll).FirstOrDefault();
                st.FirstName = student.FirstName;
                st.LastName = student.LastName;
                st.Marks = (decimal?)student.MarksSecured;
                //st.Branch = student.Branch;
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

        public bool UpdateStudentById(StudentBO student)
        {
            try
            {
                var st = _db.Student1.Where(x => x.Id == student.Id).FirstOrDefault();
                st.FirstName = student.FirstName;
                st.LastName = student.LastName;
                st.Marks = (decimal?)student.MarksSecured;

                st.DateOfBirth = student.DateOfBirth;

                _db.Student1.Add(st);
                _db.Entry(st).State = EntityState.Modified;
                if (student.BranchId.HasValue)
                {
                    var branch = _db.Branch.Find(student.BranchId); //finding record from db using primary key search
                    branch.Name = student.Branch; //change it to name
                    _db.Branch.Add(branch); //add it to the table
                    _db.Entry(branch).State = EntityState.Modified; //
                }
                else
                {
                    if (!string.IsNullOrEmpty(student.Branch))
                    {
                        var newbranch = _db.Branch.Add(new Branch { Name = student.Branch });
                        st.Branch = newbranch.Entity;
                    }
                }

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

        public bool DeleteStudentById(int id)
        {
            try
            {
                var students = _db.Student1.Where(x => x.Id == id);
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
    }
}

