using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizApplicationMVCDotNetFramework.DB;
using QuizApplicationMVCDotNetFramework.BO;

namespace QuizApplicationMVCDotNetFramework.DAL
{
    public class UserDAL
    {
        private readonly Entities _db;
        public UserDAL()
        {
            _db = new Entities();
        }
        public bool CreateUser(UserBO user)
        {
            
                var success = true;
                try
                {
                    

                    _db.Usertable.Add(new Usertable
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        

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
        //public bool CalculateMarks()
        //{

           
               
        //}

    }
}
