using StudentRecords.Web.Controllers;
using System;
using Xunit;

namespace StudentRecords.WebApi.UnitTests
{
    public class StudentControllerTest
    {
        protected StudentController _testController { get; }

        public StudentControllerTest()
        {
            _testController = new StudentController();
        }

        public class GetStudents : StudentControllerTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class GetStudentByStudentId : StudentControllerTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class AddStudents : StudentControllerTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class AddStudent : StudentControllerTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class DeleteStudents : StudentControllerTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class DeleteStudent : StudentControllerTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class UpdateStudents : StudentControllerTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class UpdateStudent : StudentControllerTest
        {
            [Fact]
            public void Test1()
            {

            }
        }
    }
}
