using StudentRecords.WebApi.Repositories;
using StudentRecords.WebApi.Models;
using System.Collections.Generic;

namespace StudentRecords.WebApi.Services
{
    public class StudentService
    {
        private StudentRepository _studentRepository;

        public StudentService(string folderPath, string fileName)
        {
            _studentRepository = new StudentRepository(folderPath, fileName);
        }

        public List<Student> GetStudents() => _studentRepository.GetStudents();

        public Student GetStudentByStudentId(int studentId) => _studentRepository.GetStudentByStudentId(studentId);

        public void AddStudents(List<Student> students) => _studentRepository.AddStudents(students);

        public void AddStudent(Student student) => AddStudents(new List<Student>() { student });

        public void DeleteStudents(List<int> studentIds) => _studentRepository.DeleteStudents(studentIds);

        public void DeleteStudent(int studentId) => DeleteStudents(new List<int>() { studentId });

        public void UpdateStudents(List<Student> students) => _studentRepository.UpdateStudents(students);

        public void UpdateStudent(Student student) => UpdateStudents(new List<Student>() { student });
    }
}