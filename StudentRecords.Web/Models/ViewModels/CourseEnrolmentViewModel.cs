using System;
using System.Collections.Generic;

namespace StudentRecords.Web.Models.ViewModels
{
    public class CourseEnrolmentViewModel
    {
        public string EnrolmentID { get; set; }
        public string AcademicYear { get; set; }
        public string YearOfStudy { get; set; }
        public string Occurrence { get; set; }
        public string ModeOfAttendance { get; set; }
        public string EnrolmentStatus { get; set; }
        public string CourseEntryDate { get; set; }
        public string ExpectedEndDate { get; set; }
        public List<CourseViewModel> Courses { get; set; }
    }
}
