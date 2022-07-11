using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using StudentRecords.Web.Models.DTOs;
using StudentRecords.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StudentRecords.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
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

        // [HttpGet]
        // [ProducesResponseType(typeof(List<Enrolment>), StatusCodes.Status200OK)]
        // public IActionResult GetCourseEnrolmentByStudentId(int studentId)
        // {
        //     List<Enrolment> courses = _courseEnrolmentService.GetCourseEnrolmentByStudentId(studentId);
        //     return Ok(courses);
        // }

        // [HttpGet]
        // [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]
        // public IActionResult GetAvailableCoursesByStudentId(int studentId)
        // {
        //     List<Course> courses = _courseEnrolmentService.GetAvailableCoursesByStudentId(studentId);
        //     return Ok(courses);
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult EnrolCourses(int studentId, List<Enrolment> courseEnrolment)
        // {
        //     _courseEnrolmentService.EnrolCourses(studentId, courseEnrolment);
        //     return Ok();
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult EnrolCourse(int studentId, Enrolment courseEnrolment)
        // {
        //     _courseEnrolmentService.EnrolCourse(studentId, courseEnrolment);
        //     return Ok();
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult DisenrollCourses(int studentId, List<string> enrolmentIds)
        // {
        //     _courseEnrolmentService.DisenrollCourses(studentId, enrolmentIds);
        //     return Ok();
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult DisenrollCourse(int studentId, string enrolmentId)
        // {
        //     _courseEnrolmentService.DisenrollCourse(studentId, enrolmentId);
        //     return Ok();
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult UpdateCourseEnrolment(int studentId, List<Enrolment> courseEnrolment)
        // {
        //     _courseEnrolmentService.UpdateCourseEnrolment(studentId, courseEnrolment);
        //     return Ok();
        // }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public IActionResult UpdateCourseEnrolment(int studentId, Enrolment courseEnrolment)
        // {
        //     _courseEnrolmentService.UpdateCourseEnrolment(studentId, courseEnrolment);
        //     return Ok();
        // }
    }
}