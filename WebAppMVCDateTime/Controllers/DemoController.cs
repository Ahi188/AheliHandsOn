using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVCDateTime.DAL;
using WebAppMVCDateTime.BO;

namespace WebAppMVCDateTime.Controllers
{
    public class DemoController : Controller
    {
         private readonly StudentDAL _studentDAL;
        public DemoController()
        {
            _studentDAL=new StudentDAL();
        }
        // GET: Demo
        public ActionResult GetAllStudents()
        {
            var students=_studentDAL.GetStudents();
            return View("~/Views/Student/Students.cshtml",students);
        }
        public ActionResult GetAllStudentsJsonView()
        {

            return View("~/Views/Student/StudentsJsonView.cshtml");
        }
        public JsonResult GetAllStudentsJSON()
        {
            var students = _studentDAL.GetStudents();
           return Json(students, JsonRequestBehavior.AllowGet);
        }
        [HttpPost] //post data from ui to server
        public ActionResult CreateStudent(StudentBO student)
        {
            if (!string.IsNullOrEmpty(student.FirstName) && !string.IsNullOrEmpty(student.LastName) && student.Roll != null)
            {
                _studentDAL.CreateStudent(student);

                return RedirectToAction("GetAllStudents");
            }
            else
            {
                ViewBag.ValidationError = "Please Fill in First Name, Last Name & Roll Number.";
            }
            return View(new StudentBO());

        }

        [HttpGet] //read anything from ui
        public ActionResult CreateStudent()
        {
           
            return View(new StudentBO());
        }
        [HttpGet]
        public ActionResult CreateStudentAjax() // ajax 
        {
            return View(new StudentBO());
        }
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = _studentDAL.GetStudentById(id);
            return View(student);
            //return RedirectToAction("GetAllStudents");
        }
        [HttpPost]
        public JsonResult CreateStudentAjax(StudentBO student)
        {
            var error = string.Empty;
            if(!string.IsNullOrEmpty(student.FirstName)&&!string.IsNullOrEmpty(student.LastName) && student.Roll!= null)
            {
                var success = _studentDAL.CreateStudent(student);
                return Json(new {Success=true, Error=error}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                error = "Fill First Name, Last Name and Roll Number";
                return Json(new {Success=false,Error=error}, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult EditStudent(StudentBO student)
        {
            if(!string.IsNullOrEmpty(student.FirstName) && !string.IsNullOrEmpty(student.LastName) && student.Roll != null && student.Id>0)
            {
                _studentDAL.UpdateStudentById(student);
                return RedirectToAction("GetAllStudents");
            }
            else
            {
                ViewBag.ValidationErrors = "Please fill First Name, Last Name & Roll Number.";
            }
            return View(new StudentBO());
        }
        //[HttpPost]
        public ActionResult Delete (int id)
        {
            StudentDAL student= new StudentDAL();
           student.DeleteStudentById(id);
            return RedirectToAction("GetAllStudents");
        }


    }
}