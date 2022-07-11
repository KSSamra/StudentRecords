using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using StudentRecords.Web.Models.DTOs;
using StudentRecords.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentRecords.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private string apiAddress = "";
        // string apiUrl = ConfigurationManager.AppSettings["baseurl"] + "/api/Values/";

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Search(StudentFiltersDTO searchFilters)
        {
            List<StudentViewModel> studentRecords = new List<StudentViewModel>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiAddress);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Student/Search");

                if (response.IsSuccessStatusCode)
                {
                    var studentResponse = response.Content.ReadAsStringAsync().Result;
                    studentRecords = JsonSerializer.Deserialize<List<StudentViewModel>>(studentResponse);
                }
            }

            return View(studentRecords);
        }

        // [HttpGet]
        // [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
        // public IActionResult GetStudentByStudentId(int studentId)
        // {
        //     Student student = _studentService.GetStudentByStudentId(studentId);
        //     return Ok(student);
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult AddStudents(List<Student> students)
        // {
        //     _studentService.AddStudents(students);
        //     return Ok();
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult AddStudent(Student student)
        // {
        //     _studentService.AddStudent(student);
        //     return Ok();
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult DeleteStudents(List<int> studentIds)
        // {
        //     _studentService.DeleteStudents(studentIds);
        //     return Ok();
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult DeleteStudent(int studentId)
        // {
        //     _studentService.DeleteStudent(studentId);
        //     return Ok();
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult UpdateStudents(List<Student> students)
        // {
        //     _studentService.UpdateStudents(students);
        //     return Ok();
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult UpdateStudent(Student student)
        // {
        //     _studentService.UpdateStudent(student);
        //     return Ok();
        // }
    }
}