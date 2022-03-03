using WebAPI.BO;
using WebAPI.DB;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private readonly TrainingDbContext _db;
        private readonly ILogger<StudentDAL> _logger;

        public StudentDAL(TrainingDbContext db,ILogger<StudentDAL> logger)
        {
            _db = db;
            _logger = logger;
        }

        //get all the students
        public IEnumerable<StudentBO> GetStudents()
        {
            return _db.Student1.Select(x => new StudentBO
            {
                Id=x.Id,
                FirstName=x.FirstName,
                LastName=x.LastName,
                RollNo = x.RollNumber,
                Marks = x.Marks,
                BranchId =x.BranchId,
                Branch=x.Branch.Name

            }).ToList();
        }

        //get a student by id
        public StudentBO GetStudent(int id)  //getMenu(indian)
        {
            return _db.Student1.Select(x => new StudentBO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                RollNo=x.RollNumber,
                Marks=x.Marks,
                BranchId = x.BranchId,
                Branch = x.Branch.Name

            }).FirstOrDefault();
        }


        //create student
        public bool CreateStudent(StudentBO student)
        {
            var success = true;
            try
            {
                _db.Student1.Add(new Student1
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    RollNumber = student.RollNo,
                    Marks = student.Marks,
                   // Branch = student.Branch,
                    

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


        //edit student 
        public bool EditStudent(StudentBO student)
        {
            try
            {
                var st = _db.Student1.Where(x => x.Id == student.Id).FirstOrDefault();
                st.FirstName = student.FirstName;
                st.LastName = student.LastName;
                st.RollNumber=student.RollNo;   
                st.Marks = (decimal?)student.Marks;
                //st.Branch = student.Branch;
                _db.Student1.Add(st);
                _db.Entry(st).State = EntityState.Modified; //Whenever we edit the entry
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

        //delete student by id
        public bool DeleteStudentById(int id)
        {
            try
            {
                var students = _db.Student1.Where(x => x.Id == id ); 
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

