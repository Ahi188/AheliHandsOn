using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApplicationMVCDotNetFramework.BO;
using QuizApplicationMVCDotNetFramework.DAL;


namespace QuizApplicationMVCDotNetFramework.Controllers
{

    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index()
        {
            return View();
        }
        private readonly QuizDAL _quizDAL;
        public QuizController()
        {
            _quizDAL = new QuizDAL();
        }

        // GET: Demo
        [HttpGet]
        public ActionResult GetQuiz(int Qid=1) //get the questions from DB
        {
            
            var quiz = _quizDAL.GetQuiz(Qid);
            return View("~/Views/Quiz/GetQuiz.cshtml", quiz);
            
        }
        [HttpPost]
        public ActionResult GetQuiz(QuizBO quiz,string submit) //get the answers update them to DB
        {
            var questions =_quizDAL.GetQuiz();
            quiz.Userguid = Convert.ToString(Session["usersessionid"]);
            quiz.Userid = _quizDAL.GetUserId(quiz.Userguid);
            var ans2 = _quizDAL.GetAnswer(quiz);
            if(submit =="Next")
            { 
                return RedirectToAction("GetQuiz", new { Qid = quiz.Qid + 1 });
            }
            
            else
            {
                return RedirectToAction("GetQuiz", new { Qid = quiz.Qid - 1 });
            }
            

        }




    }
}

