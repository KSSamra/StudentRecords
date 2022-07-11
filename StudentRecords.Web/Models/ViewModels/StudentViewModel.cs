using System;
using System.Collections.Generic;

namespace StudentRecords.Web.Models.ViewModels
{
    public class StudentViewModel
    {
        public string StudentID { get; set; }
        public string NetworkID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string KnownAs { get; set; }
        public string DisplayName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string UniversityEmail { get; set; }
        public bool IsOverseas { get; set; }
        public CourseEnrolmentViewModel CourseEnrolment { get; set; }
    }
}
