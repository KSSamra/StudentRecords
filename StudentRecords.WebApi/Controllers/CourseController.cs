using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentRecords.WebApi.Models;
using StudentRecords.WebApi.Services;
using System;
using System.Collections.Generic;

namespace StudentRecords.WebApi.Controllers
{
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private CourseEnrolmentService _courseEnrolmentService;

        public CourseController()
        {
            string folderPath = "~/Data";
            string coursesFileName = "Courses.json";
            string studentsFileName = "students.json";
            _courseEnrolmentService = new CourseEnrolmentService(folderPath, coursesFileName, studentsFileName);
        }

        [Route("")]
        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Enrolment>), StatusCodes.Status200OK)]
        public IActionResult GetCourseEnrolmentByStudentId(int studentId)
        {
            List<Enrolment> courses = _courseEnrolmentService.GetCourseEnrolmentByStudentId(studentId);
            return Ok(courses);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]
        public IActionResult GetAvailableCoursesByStudentId(int studentId)
        {
            List<Course> courses = _courseEnrolmentService.GetAvailableCoursesByStudentId(studentId);
            return Ok(courses);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult EnrolCourses(int studentId, List<Enrolment> courseEnrolment)
        {
            _courseEnrolmentService.EnrolCourses(studentId, courseEnrolment);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult EnrolCourse(int studentId, Enrolment courseEnrolment)
        {
            _courseEnrolmentService.EnrolCourse(studentId, courseEnrolment);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DisenrollCourses(int studentId, List<string> enrolmentIds)
        {
            _courseEnrolmentService.DisenrollCourses(studentId, enrolmentIds);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DisenrollCourse(int studentId, string enrolmentId)
        {
            _courseEnrolmentService.DisenrollCourse(studentId, enrolmentId);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateCourseEnrolment(int studentId, List<Enrolment> courseEnrolment)
        {
            _courseEnrolmentService.UpdateCourseEnrolment(studentId, courseEnrolment);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateCourseEnrolment(int studentId, Enrolment courseEnrolment)
        {
            _courseEnrolmentService.UpdateCourseEnrolment(studentId, courseEnrolment);
            return Ok();
        }
    }
}