using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecords.WebApi.Models;
using StudentRecords.WebApi.Services;
using System.Collections.Generic;

namespace StudentRecords.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private StudentService _studentService;

        public StudentController()
        {
            string folderPath = "~/Data";
            string fileName = "students.json";
            _studentService = new StudentService(folderPath, fileName);
        }

        [Route("")]
        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Student>), StatusCodes.Status200OK)]
        public IActionResult GetStudents()
        {
            List<Student> students = _studentService.GetStudents();
            return Ok(students);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
        public IActionResult GetStudentByStudentId(int studentId)
        {
            Student student = _studentService.GetStudentByStudentId(studentId);
            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddStudents(List<Student> students)
        {
            _studentService.AddStudents(students);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddStudent(Student student)
        {
            _studentService.AddStudent(student);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteStudents(List<int> studentIds)
        {
            _studentService.DeleteStudents(studentIds);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteStudent(int studentId)
        {
            _studentService.DeleteStudent(studentId);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateStudents(List<Student> students)
        {
            _studentService.UpdateStudents(students);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateStudent(Student student)
        {
            _studentService.UpdateStudent(student);
            return Ok();
        }
    }
}