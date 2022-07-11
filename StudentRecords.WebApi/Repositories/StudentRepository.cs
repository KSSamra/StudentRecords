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
    public class StudentRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string _filePath;

        public StudentRepository(string folderPath, string fileName)
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

        public List<Student> GetStudents()
        {
            string jsonData = File.ReadAllText(_filePath);
            List<Student> studentData = JsonSerializer.Deserialize<List<Student>>(jsonData) ?? new List<Student>();

            return studentData;
        }

        public Student GetStudentByStudentId(int studentId)
        {
            List<Student> studentData = GetStudents();
            Student student = studentData.Find(sd => sd.StudentId == studentId);

            return student;
        }

        public void AddStudents(List<Student> students)
        {
            List<Student> studentData = GetStudents();
            studentData.AddRange(students);
            
            string jsonString = JsonSerializer.Serialize(studentData);
            File.WriteAllText(_filePath, jsonString);
        }

        public void DeleteStudents(List<int> studentIds)
        {
            List<Student> studentData = GetStudents();
            List<Student> studentsToRemove = (
                from student in studentData
                join studentId in studentIds on student.StudentId equals studentId
                select student
            ).ToList();
            studentData = studentData.Except(studentsToRemove).ToList();

            string jsonString = JsonSerializer.Serialize(studentData);
            File.WriteAllText(_filePath, jsonString);
        }

        public void UpdateStudents(List<Student> students)
        {
            List<int> studentIds = students.Select(s => s.StudentId).ToList();
            
            DeleteStudents(studentIds);
            AddStudents(students);
        }
    }
}