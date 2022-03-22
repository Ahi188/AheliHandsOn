using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO;
using DAL.Data;

namespace DAL
{
    public class StudentDAL
    {
        private readonly Entities _db;
        
        public StudentDAL()
        {
            _db = new Entities();
        }

        public StudentInfoResponse CreateStudent(StudentInfoRequest request)
        {
            StudentInfoResponse student = new StudentInfoResponse();
            try
            {
                _db.Student1.Add(new Student1
                {
                    First_name = request.Body.First_name,
                    Last_name = request.Body.Last_name,
                    Roll_number = request.Body.Roll_number,
                    Marks = request.Body.Marks,

                });
                _db.SaveChanges();
                student.Header = new HeaderInfo
                {
                    CallStatus = "Success",
                    TransactionID = request?.Header?.TransactionID,
                };
            }
            catch (Exception ex)
            {
                student.Header = new HeaderInfo
                {
                    CallStatus = "Error",
                    TransactionID = request?.Header?.TransactionID,
                };
            }
            return student;
        }

        public StudentInfoResponse UpdateStudent(StudentInfoRequest request)
        {
            StudentInfoResponse student = new StudentInfoResponse();
            try
            {
                var st = _db.Student1.Where(x => x.Roll_number == request.Body.Roll_number).FirstOrDefault();
                st.First_name = request.Body.First_name;
                st.Last_name = request.Body.Last_name;
                st.Roll_number = request.Body.Roll_number;
                st.Marks = request.Body.Marks;
               
                _db.Student1.Add(st);
                _db.Entry(st).State = System.Data.Entity.EntityState.Modified; //Whenever we edit the entry
                _db.SaveChanges();
                student.Header = new HeaderInfo
                {
                    CallStatus = "Success",
                    TransactionID = request?.Header?.TransactionID,
                };

            }
            catch (Exception ex)
            {
                student.Header = new HeaderInfo
                {
                    CallStatus = "Error",
                    TransactionID = request?.Header?.TransactionID,
                };
            }
            return student;
        }

        public StudentInfoResponse DeleteStudent(StudentInfoRequest request)
        {
            StudentInfoResponse student = new StudentInfoResponse();
            try
            {
                var students = _db.Student1.Where(x => x.Roll_number == request.Body.Roll_number);
                _db.Student1.RemoveRange(students);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                student.Header = new HeaderInfo
                {
                    CallStatus = "Error",
                    TransactionID = request?.Header?.TransactionID,
                };
            }
            return student;
            
        }
    }
}