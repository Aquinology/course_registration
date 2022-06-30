using Microsoft.AspNetCore.Mvc;
using CourseRegistration.Interfaces;
using CourseRegistration.Controllers;
using CourseRegistration.Models;

namespace CorseRegistrationUnitTests
{
    internal class RegistrationSheetControllerTests
    {
        private readonly Mock<IRepositoryWrapper> _mockRepo;
        private readonly RegistrationSheetController _controller;

        public RegistrationSheetControllerTests()
        {
            _mockRepo = new Mock<IRepositoryWrapper>();
            _controller = new RegistrationSheetController(_mockRepo.Object);
        }

        private List<RegistrationSheet> GetTestRegistrationSheetList()
        {
            var registrationSheets = new List<RegistrationSheet>();
            registrationSheets.Add(new RegistrationSheet()
            {
                Id = 1,
                StudentId = 1,
                CourseId = 3
            });
            registrationSheets.Add(new RegistrationSheet()
            {
                Id = 2,
                StudentId = 2,
                CourseId = 2
            });
            registrationSheets.Add(new RegistrationSheet()
            {
                Id = 3,
                StudentId = 3,
                CourseId = 1
            });
            return registrationSheets;
        }
    }
}
