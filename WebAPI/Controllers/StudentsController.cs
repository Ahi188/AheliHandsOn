using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DAL;
using WebAPI.BO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentDAL _dal;
        public StudentsController(ILogger<StudentsController> logger, IStudentDAL dal)
        {
            _logger = logger;
            _dal = dal;
        }

        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)]
        [ProducesResponseType(type: typeof(IEnumerable<StudentBO>), statusCode: 200)]

        //get all the students
        [HttpGet("GetAllStudents")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_dal.GetStudents());
                //return BadRequest(); for validation
            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, e.Message, null);
                //throw e;
                return Problem(statusCode: 500, detail: e.Message);
            }
        }

       //get students by id
        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)]
        [ProducesResponseType(type: typeof(StudentBO), statusCode: 200)]

        [HttpGet("GetStudentById")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                if (id <= 0)
                {
                    IEnumerable<string> validationErrors = new string[] { "Validation Error- Id should be graeter than 0" };
                    return BadRequest(validationErrors);
                }
                return Ok(_dal.GetStudent(id));

            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, e.Message, null);
                //throw e;
                return Problem(statusCode: 500, detail: e.Message);
            }
        }
        //http-post method to create student

        [ProducesResponseType(statusCode: 500)] //exceptions
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)] //validation errors
        [ProducesResponseType(type: typeof(string), statusCode: 200)] //success

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent(StudentBO student)
        {
            if (!string.IsNullOrEmpty(student.FirstName) && !string.IsNullOrEmpty(student.LastName) && student.RollNo != null)
            {
                _dal.CreateStudent(student);
                string Successmsg = "The Student was created successfully";
                return Ok(Successmsg);
            }
            else
            {
                IEnumerable<string> validationErrors = new string[] { "Validation error- FirstName, LastName, Roll number required" };
                return BadRequest(validationErrors);
            }
            return Ok();
        }

        //httppost method to update student

        [ProducesResponseType(statusCode: 500)] //exceptions
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)] //validation errors
        [ProducesResponseType(type: typeof(string), statusCode: 200)] //success
        [HttpPost("EditStudent")]
        public IActionResult EditStudent(StudentBO student)
        {
            if (!string.IsNullOrEmpty(student.FirstName) )//&& !string.IsNullOrEmpty(student.LastName) && student.RollNo != null && student.Id > 0)
            {
                _dal.EditStudent(student);
                string Successmsg = "The Student was updated successfully";
                return Ok(Successmsg);
            }
            else
            {
                IEnumerable<string> validationErrors = new string[] { "Please fill First Name, Last Name & Roll Number." };
                return BadRequest(validationErrors);
            }
            return Ok();
        }


        //httpspost method to delete a student
        [ProducesResponseType(statusCode: 500)] //exceptions
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)] //validation errors
        [ProducesResponseType(type: typeof(string), statusCode: 200)] //success

        [HttpDelete("DeleteStudentById")]
        public IActionResult DeleteStudentById(int id)
        {
           
            _dal.DeleteStudentById(id);
            string Successmsg = "The Student was deleted successfully";
            return Ok(Successmsg);
        }

    }
}
