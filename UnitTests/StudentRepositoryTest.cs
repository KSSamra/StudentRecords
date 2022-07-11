using StudentRecords.WebApi.Repositories;
using System;
using Xunit;

namespace StudentRecords.WebApi.UnitTests
{
    public class StudentRepositoryTest
    {
        protected StudentRepository _testRepository { get; }

        public StudentRepositoryTest()
        {
            _testRepository = new StudentRepository("../UnitTests/TestFiles/Repositories", "StudentRepository");
        }

        public class GetStudents : StudentRepositoryTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class GetStudentByStudentId : StudentRepositoryTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class AddStudents : StudentRepositoryTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class AddStudent : StudentRepositoryTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class DeleteStudents : StudentRepositoryTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class DeleteStudent : StudentRepositoryTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class UpdateStudents : StudentRepositoryTest
        {
            [Fact]
            public void Test1()
            {

            }
        }

        public class UpdateStudent : StudentRepositoryTest
        {
            [Fact]
            public void Test1()
            {

            }
        }
    }
}
