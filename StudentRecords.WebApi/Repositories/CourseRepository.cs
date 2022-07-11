using Microsoft.AspNetCore.Hosting;
using StudentRecords.WebApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Web;

namespace StudentRecords.WebApi.Repositories
{
    public class CourseRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string _filePath;

        public CourseRepository(string folderPath, string fileName)
        {
            string mappedFolderPath = Path.Combine(_webHostEnvironment.ContentRootPath, folderPath);
            _filePath = Path.Combine(mappedFolderPath, fileName);

            if (!Directory.Exists(mappedFolderPath))
            {
                Directory.CreateDirectory(mappedFolderPath);
            }
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, null);
            }
        }

        public List<Course> GetCourses()
        {
            string jsonData = File.ReadAllText(_filePath);
            List<Course> courseData = JsonSerializer.Deserialize<List<Course>>(jsonData);

            return courseData;
        }

        public void AddCourses(List<Course> courses)
        {
            List<Course> courseData = GetCourses();
            courseData.AddRange(courses);
            
            string jsonString = JsonSerializer.Serialize(courseData);
            File.WriteAllText(_filePath, jsonString);
        }

        public void DeleteCourses(List<string> courseCodes)
        {
            List<Course> courseData = GetCourses();
            List<Course> coursesToRemove = (
                from course in courseData
                join courseCode in courseCodes on course.CourseCode equals courseCode
                select course
            ).ToList();
            courseData = courseData.Except(coursesToRemove).ToList();

            string jsonString = JsonSerializer.Serialize(courseData);
            File.WriteAllText(_filePath, jsonString);
        }

        public void UpdateCourses(List<Course> courses)
        {
            List<string> courseCodes = courses.Select(c => c.CourseCode).ToList();
            
            DeleteCourses(courseCodes);
            AddCourses(courses);
        }
    }
}