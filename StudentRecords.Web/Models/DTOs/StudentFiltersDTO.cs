using System;

namespace StudentRecords.Web.Models.DTOs
{
    public class StudentFiltersDTO
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
        public bool HomeOrOverseas { get; set; }
        public CourseFiltersDTO course { get; set; }
    }
}
