﻿using System;
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
                    Userid = quiz.Userid,

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
            int userid = _db.Usertable.Where(u => u.Userguid == UserGuid).Select(x => x.Userid).FirstOrDefault();
            return userid;
        }

        //public QuizBO GetCorrectAns(int id)
        //{

        //    var quiz = _db.OnlineExam.Where(x => x.Qid == id).Select(x => new QuizBO
        //    {
        //        Qid = x.Qid,
        //        Question = x.Question,
        //        CorrectAns=x.CorrectAns, //correct ans

        //    }).FirstOrDefault();

        //    var chosen = _db.ChosenAnswer.Where(x => x.Qid == id).Select(x => new QuizBO
        //    {
        //        Qid = (int)x.Qid,
        //        Answer = x.Answer, //given ans

        //    }).FirstOrDefault();

        //var marks = 0;
        ////if (quiz != null)
        ////    if(QuizBO.Qid != 0 || )            

        //foreach (var i in _db.OnlineExam) //for each qid in Online exam
        //{
        //    QuizBO result=_db.ChosenAnswer.Where(a=>a.Qid==i.Qid).Select(a=> new QuizBO
        //    {

        //    })
        //}
        //return quiz;

        //}
       
        public IEnumerable<AnswerBO> GetResult(int Userid)
        {
            var result = from a in _db.OnlineExam
                         join h in _db.ChosenAnswer on a.CorrectAns equals h.Answer
                         join c in _db.Usertable on h.Userid equals c.Userid
                         where c.Userid == Userid
                         select new AnswerBO
                         {
                             QId = a.Qid,
                             Question = a.Question,
                             Answer = a.CorrectAns,
                             ChosenAnswer = h.Answer,
                             UserId = c.Userid,

                         };
            return result;

        }
        //public int GetMarks(int Userid)
        //{
            //var marks = (from a in _db.OnlineExam
            //             join b in _db.ChosenAnswer on a.CorrectAns equals b.Answer
            //             where b.Userid == Userid).Count();
            //int count = _db.OnlineExam.Join(_db.ChosenAnswer, c => c.CorrectAns, p => p.Answer, (c, p) => new { OnlineExam= c, ChosenAnswer = p }).Count();

            //return count;
            
        //}
        public ResultBO GetResultVM(int userid)
        {
            ResultBO resultBO = null;

            resultBO = _db.Usertable.Where(p => p.Userid == userid)
                       .Select(x => new ResultBO
                       {
                           FirstName = x.FirstName,
                           LastName = x.LastName,
                           UserId=x.Userid,
                           Email = x.Email,

                           Marks = (_db.ChosenAnswer.Where(u => u.Userid == userid).Join(
                                    _db.OnlineExam,
                                    q => new { QidColumn = (int)q.Qid, AnsColumn = (string)q.Answer },
                                    u => new { QidColumn = (int)u.Qid, AnsColumn = (string)u.CorrectAns },
                                    (q, u) => new { u.ChosenAnswer }).Count()),

                           

                           Fullmarks = (_db.OnlineExam.Count()),

                           Answers = (from a in _db.OnlineExam
                                      join h in _db.ChosenAnswer on a.Qid equals h.Qid
                                      join c in _db.Usertable on h.Userid equals c.Userid
                                      where c.Userid == userid
                                      select new AnswerBO
                                      {
                                          QId = a.Qid,
                                          Question = a.Question,
                                          Answer = a.CorrectAns,
                                          ChosenAnswer = h.Answer,
                                          UserId = c.Userid
                                      })
                       }).FirstOrDefault();
            return resultBO;
        }

        public int GetMarks(int userid)
        {
            int marks = (_db.ChosenAnswer.Where(u => u.Userid == userid).Join(
            _db.OnlineExam,
                     q => new { QidColumn = (int)q.Qid, AnsColumn = (string)q.Answer },
                     u => new { QidColumn = (int)u.Qid, AnsColumn = (string)u.CorrectAns },
                     (q, u) => new { u.ChosenAnswer }).Count());
            return marks;
        }
    }
}
    