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
        public ActionResult GetQuiz(QuizBO quiz) //get the answers update them to DB
        {
            var questions =_quizDAL.GetQuiz();
            quiz.Userid = Convert.ToInt32(Session["usersessionid"]);
            var ans2 = _quizDAL.GetAnswer(quiz);
            //if button is 0/1-> assign a int value-> if condition here
            return RedirectToAction("GetQuiz",new { Qid = quiz.Qid + 1 });
            //hidden variable concept -> assign value 0,1 ->  Quid-1 for prev

        }




    }
}

