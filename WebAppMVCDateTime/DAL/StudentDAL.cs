using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMVCDateTime.BO;
using WebAppMVCDateTime.DB;

namespace WebAppMVCDateTime.DAL
{
    public class StudentDAL
    {
        private readonly TrainingEntity _db;//wrapper of database
        public StudentDAL()
        {
            _db = new TrainingEntity();
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
                        branchId = createBranch.Id;
                    }
                }

                _db.Student1.Add(new Student1
                {
                    First_name = student.FirstName,
                    Last_name = student.LastName,
                    Roll_number = student.Roll,
                    Marks = student.MarksSecured,
                    BranchId = branchId,
                    Date_of_Birth = student.DateOfBirth,
                   
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
                var result = _db.CreateStudent(student.FirstName, student.LastName, student.Roll, student.MarksSecured);
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
                Id= x.Id, //get the id
                FirstName = x.First_name,
                LastName = x.Last_name,
                Roll = x.Roll_number,
                MarksSecured = x.Marks,
                BranchId = x.Branch.Id,
                DateOfBirth=x.Date_of_Birth,
                
            }).FirstOrDefault();

            return student;
        }
        public StudentBO GetStudentById(int id)
        {
            var student = _db.Student1.Where(r => r.Id == id).Select(x => new StudentBO
            {
                Id = x.Id, //get the id
                FirstName = x.First_name,
                LastName = x.Last_name,
                Roll = x.Roll_number,
                MarksSecured = x.Marks,
                BranchId = x.Branch.Id,
                Branch=x.Branch.Name,
                DateOfBirth= x.Date_of_Birth,
                
            }).FirstOrDefault();
            return student;
        }

        public List<StudentBO> GetStudents()
        {
            var list = _db.Student1.Select(x => new StudentBO
            {
                Id = x.Id, //fetch the id
                FirstName = x.First_name,
                LastName = x.Last_name,
                Roll = x.Roll_number,
                MarksSecured = x.Marks,
                BranchId = x.Branch.Id,
                Branch= x.Branch.Name,
                DateOfBirth = x.Date_of_Birth,
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
                //st.Branch = student.Branch;
                _db.Student1.Add(st);
                _db.Entry(st).State = System.Data.Entity.EntityState.Modified;
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
                st.First_name = student.FirstName;
                st.Last_name = student.LastName;
                st.Marks = (decimal?)student.MarksSecured;
               
                st.Date_of_Birth=student.DateOfBirth;

                _db.Student1.Add(st);
                _db.Entry(st).State = System.Data.Entity.EntityState.Modified;
                if (student.BranchId.HasValue)
                {
                    var branch = _db.Branch.Find(student.BranchId); //finding record from db using primary key search
                    branch.Name = student.Branch; //change it to name
                    _db.Branch.Add(branch); //add it to the table
                    _db.Entry(branch).State = System.Data.Entity.EntityState.Modified; //
                }
                else
                {
                    if (!string.IsNullOrEmpty(student.Branch))
                    {
                        var newbranch = _db.Branch.Add(new Branch { Name = student.Branch });
                        st.Branch = newbranch;
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
