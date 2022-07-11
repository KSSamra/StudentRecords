using StudentRecords.WebApi.Repositories;
using StudentRecords.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentRecords.WebApi.Services
{
    public class CourseEnrolmentService
    {
        private CourseRepository _courseRepository;
        private StudentRepository _studentRepository;

        public CourseEnrolmentService(string folderPath, string courseFileName, string studentFileName)
        {
            _courseRepository = new CourseRepository(folderPath, courseFileName);
            _studentRepository = new StudentRepository(folderPath, studentFileName);
        }

        public List<Course> GetCourses()
        {
            List<Course> availableCourses = _courseRepository.GetCourses();

            return availableCourses;
        }

        public List<Enrolment> GetCourseEnrolmentByStudentId(int studentId)
        {
            Student studentData = _studentRepository.GetStudentByStudentId(studentId);
            List<Enrolment> courseEnrolmentData = studentData.CourseEnrolment;

            return courseEnrolmentData;
        }

        public List<Course> GetAvailableCoursesByStudentId(int studentId)
        {
            Student studentData = _studentRepository.GetStudentByStudentId(studentId);
            List<Enrolment> courseEnrolmentData = studentData.CourseEnrolment;

            List<Course> enrolledCourses = courseEnrolmentData.Select(ce => ce.Course).ToList();
            List<Course> availableCourses = _courseRepository.GetCourses().Except(enrolledCourses).ToList();

            return availableCourses;
        }

        public void EnrolCourses(int studentId, List<Enrolment> courseEnrolment)
        {
            Student studentData = _studentRepository.GetStudentByStudentId(studentId);
            studentData.CourseEnrolment.AddRange(courseEnrolment);

            _studentRepository.UpdateStudents(new List<Student>() { studentData });
        }

        public void EnrolCourse(int studentId, Enrolment courseEnrolment) => EnrolCourses(studentId, new List<Enrolment>() { courseEnrolment });

        public void DisenrollCourses(int studentId, List<string> enrolmentIds)
        {
            Student studentData = _studentRepository.GetStudentByStudentId(studentId);
            List<Enrolment> coursesToDisenroll = (
                from enrolment in studentData.CourseEnrolment
                join enrolmentId in enrolmentIds on enrolment.EnrolmentId equals enrolmentId
                select enrolment
            ).ToList();
            studentData.CourseEnrolment = studentData.CourseEnrolment.Except(coursesToDisenroll).ToList();

            _studentRepository.UpdateStudents(new List<Student>() { studentData });
        }

        public void DisenrollCourse(int studentId, string enrolmentId) => DisenrollCourses(studentId, new List<string>() { enrolmentId });

        public void UpdateCourseEnrolment(int studentId, List<Enrolment> courseEnrolment)
        {
            Student studentData = _studentRepository.GetStudentByStudentId(studentId);
            List<Enrolment> coursesToUpdate = (
                from enrolment in studentData.CourseEnrolment
                join enrolmentToUpdate in courseEnrolment on enrolment.EnrolmentId equals enrolmentToUpdate.EnrolmentId
                select enrolment
            ).ToList();

            studentData.CourseEnrolment = studentData.CourseEnrolment.Except(coursesToUpdate).ToList();
            studentData.CourseEnrolment.AddRange(courseEnrolment);

            _studentRepository.UpdateStudents(new List<Student>() { studentData });
        }

        public void UpdateCourseEnrolment(int studentId, Enrolment courseEnrolment) => UpdateCourseEnrolment(studentId, new List<Enrolment>() { courseEnrolment });
    }
}