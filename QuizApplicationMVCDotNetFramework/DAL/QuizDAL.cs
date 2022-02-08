using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizApplicationMVCDotNetFramework.BO;
using QuizApplicationMVCDotNetFramework.DB;

namespace QuizApplicationMVCDotNetFramework.DAL
{
    public class QuizDAL
    {
        private readonly Entities _db;
        public QuizDAL()
        {
            _db = new Entities();
        }

        public QuizBO GetQuiz(int? id = 1)
        {

            var quiz = _db.OnlineExam.Where(x => x.Qid == id).Select(x => new QuizBO
            {
                Qid = x.Qid,
                Question = x.Question,
                Option1 = x.Option1,
                Option2 = x.Option2,
                Option3 = x.Option3,
                Option4 = x.Option4,

            }).FirstOrDefault();
            return quiz;
        }
        public bool GetAnswer(QuizBO quiz)
        {
            var success = true;
            try
            {
                _db.ChosenAnswer.Add(new ChosenAnswer
                {
                    Ansid = quiz.Ansid,
                    Answer = quiz.Option,
                    Qid = quiz.Qid,
                    Userid=quiz.Userid,
                    
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
        public int GetUserId(string UserGuid)
        {
            int userid=_db.Usertable.Where(u=>u.Userguid==UserGuid).Select(x=>x.Userid).FirstOrDefault();
            return userid;
        }
       

    }
    }
