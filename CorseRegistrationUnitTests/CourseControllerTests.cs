using Microsoft.AspNetCore.Mvc;
using CourseRegistration.Interfaces;
using CourseRegistration.Controllers;
using CourseRegistration.Models;

namespace CorseRegistrationUnitTests
{
    public class CourseControllerTests
    {

        private List<Course> GetTestCourseList()
        {
            var courses = new List<Course>();
            courses.Add(new Course()
            {
                Id = 1,
                Name = "Operating System"
            });
            courses.Add(new Course()
            {
                Id = 2,
                Name = "Information Security"
            });
            return courses;
        }

        [Fact]
        public async void ListTest()
        {
            // Arrange
            var mock = new Mock<IRepositoryWrapper>();
            mock.Setup(r => r.Courses.GetList())
                .ReturnsAsync(GetTestCourseList());
            var controller = new CourseController(mock.Object);

            // Act
            var result = await controller.List();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Course>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
    }
}