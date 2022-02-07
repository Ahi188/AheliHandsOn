using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.BO;

namespace EntityFramework.DAL
{
    public class StudentDAL: IStudentDAL
    {
        private readonly TrainingEntitiesConnectionString _db;//wrapper of database
        public StudentDAL()
        {
            _db = new TrainingEntitiesConnectionString();
        }
        public bool CreateStudent(BO.Student student)
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
                        branchId = createBranch.Id;
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
                success= false;
                throw;
            }
            return success; 
        }

        public bool CreateStudentWithSP(BO.Student student)
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

        public BO.Student GetStudentByRollNumber(int rollNo)
        {
            var student=_db.Student1.Where(r=>r.Roll_number == rollNo).Select(x =>new BO.Student
            {
                FirstName= x.First_name,
                LastName= x.Last_name,
                Roll= x.Roll_number,
                MarksSecured= x.Marks,   
                Branch= x.Branch.Name
            }).FirstOrDefault();

            return student;
        }

        public List<BO.Student> GetStudents()
        {
           var list=_db.Student1.Select(x => new BO.Student
           {
               FirstName= x.First_name,
               LastName = x.Last_name,
               Roll=x.Roll_number,
               MarksSecured=x.Marks,
               Branch=x.First_name
           }).ToList();
            return list;    
        }

        public bool UpdateStudent(BO.Student student)
        {
            try
            {
                var st = _db.Student1.Where(x => x.Roll_number == student.Roll).FirstOrDefault();
                st.First_name = student.FirstName;
                st.Last_name = student.LastName;
                st.Marks = (decimal?)student.MarksSecured;
                _db.Student1.Add(st);
                _db.Entry(st).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            catch(Exception ex)
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
