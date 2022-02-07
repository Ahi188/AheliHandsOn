using Microsoft.AspNetCore.Mvc;
using WebApplicationDotNetCoreDateTime.BO;
using WebApplicationDotNetCoreDateTime.DAL;

namespace WebApplicationDotNetCoreDateTime.Controllers
{
    public class DemoController : Controller
    {
        private readonly StudentDAL _studentDAL;
        public DemoController()
        {
            _studentDAL = new StudentDAL();
        }
        // GET: Demo
        public ActionResult GetAllStudents()
        {
            var students = _studentDAL.GetStudents();
            return View("~/Views/Student/Students.cshtml", students);
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
        public ActionResult EditStudent(int id)
        {
            var student = _studentDAL.GetStudentById(id);
            return View(student);
            //return RedirectToAction("GetAllStudents");
        }
        [HttpPost]
        public ActionResult EditStudent(StudentBO student)
        {
            if (!string.IsNullOrEmpty(student.FirstName) && !string.IsNullOrEmpty(student.LastName) && student.Roll != null && student.Id > 0)
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
        public ActionResult Delete(int id)
        {
            StudentDAL student = new StudentDAL();
            student.DeleteStudentById(id);
            return RedirectToAction("GetAllStudents");
        }


    }
}
