using StudentRecords.WebApi.Services;
using System;
using Xunit;

namespace StudentRecords.WebApi.UnitTests
{
    public class StudentServiceTest
    {
        protected StudentService _testService { get; }

        public StudentServiceTest()
        {
            _testService = new StudentService("../UnitTests/TestFiles/Repositories", "StudentService");
        }

        public class GetStudents : StudentServiceTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class GetStudentByStudentId : StudentServiceTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class AddStudents : StudentServiceTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class AddStudent : StudentServiceTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class DeleteStudents : StudentServiceTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class DeleteStudent : StudentServiceTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class UpdateStudents : StudentServiceTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class UpdateStudent : StudentServiceTest
        {
            [Fact]
            public void Test1()
            {

            }
        }
    }
}
