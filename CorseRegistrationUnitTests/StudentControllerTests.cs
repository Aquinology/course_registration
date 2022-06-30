using Microsoft.AspNetCore.Mvc;
using CourseRegistration.Interfaces;
using CourseRegistration.Controllers;
using CourseRegistration.Models;

namespace CorseRegistrationUnitTests
{
    internal class StudentControllerTests
    {
        private readonly Mock<IRepositoryWrapper> _mockRepo;
        private readonly StudentController _controller;

        public StudentControllerTests()
        {
            _mockRepo = new Mock<IRepositoryWrapper>();
            _controller = new StudentController(_mockRepo.Object);
        }

        private List<Student> GetTestStudentList()
        {
            var students = new List<Student>();
            students.Add(new Student()
            {
                Id = 1,
                Name = "Ismailkhanova Indira",
                StudentId = 1139,
                Group = "IT-119"
            });
            students.Add(new Student()
            {
                Id = 2,
                Name = "Bashanov Aleksandr",
                StudentId = 1151,
                Group = "IT-119"
            });
            students.Add(new Student()
            {
                Id = 3,
                Name = "Riabova Elena",
                StudentId = 1135,
                Group = "IT-119"
            });
            return students;
        }
    }
}
