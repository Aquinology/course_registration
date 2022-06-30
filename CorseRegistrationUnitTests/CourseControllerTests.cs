using Microsoft.AspNetCore.Mvc;
using CourseRegistration.Interfaces;
using CourseRegistration.Controllers;
using CourseRegistration.Models;

namespace CorseRegistrationUnitTests
{
    public class CourseControllerTests
    {
        private readonly Mock<IRepositoryWrapper> _mockRepo;
        private readonly CourseController _controller;

        public CourseControllerTests()
        {
            _mockRepo = new Mock<IRepositoryWrapper>();
            _controller = new CourseController(_mockRepo.Object);
        }

        private List<Course> testCourses = new List<Course>() 
        {
            new Course()
            {
                Id = 1,
                Name = "Operating System"
            },
            new Course()
            {
                Id = 2,
                Name = "Information Security"
            },
            new Course()
            {
                Id = 3,
                Name = "Data Base Technology"
            }
        };

        // List
        [Fact]
        public async void List_ActionExecutes_ReturnsViewResultType()
        {
            _mockRepo.Setup(repo => repo.Courses.GetList())
                .ReturnsAsync(testCourses);

            var result = await _controller.List();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void List_ActionExecutes_ReturnsExactNumberOfCourses()
        {
            _mockRepo.Setup(repo => repo.Courses.GetList())
                .ReturnsAsync(testCourses);

            var result = await _controller.List();

            var viewResult = Assert.IsType<ViewResult>(result);
            var courses = Assert.IsType<List<Course>>(viewResult.Model);
            Assert.Equal(3, courses.Count);
        }

        // Create
        [Fact]
        public void Create_ActionExecutes_ReturnsViewResultType()
        {
            var result = _controller.Create();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Create_InvalidModelState_ReturnsView()
        {
           _controller.ModelState.AddModelError("Name", "Name is required");
            var course = new Course { Id = 1 };

            var result = await _controller.Create(course);

            var viewResult = Assert.IsType<ViewResult>(result);
            var testCourse = Assert.IsType<Course>(viewResult.Model);
            Assert.Equal(course.Id, testCourse.Id);
        }

        [Fact]
        public async Task Create_InvalidModelState_CreateCourseNeverExecutes()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");
            var course = new Course { Id = 1 };

            await _controller.Create(course);

            _mockRepo.Verify(repo => repo.Courses.Add(It.IsAny<Course>()), Times.Never);
        }

        [Fact]
        public async Task Create_ModelStateValid_CreateCourseCalledOnce()
        {
            Course? newCourse = null;
            _mockRepo.Setup(repo => repo.Courses.Add(It.IsAny<Course>()))
                .Callback<Course>(s => newCourse = s);
            var course = testCourses.First();

            await _controller.Create(course);

            _mockRepo.Verify(repo => repo.Courses.Add(It.IsAny<Course>()), Times.Once);
            Assert.Equal(newCourse.Id, course.Id);
            Assert.Equal(newCourse.Name, course.Name);
        }

        [Fact]
        public async Task Create_ActionExecuted_RedirectsToListAction()
        {
            _mockRepo.Setup(repo => repo.Courses.Add(It.IsAny<Course>()));
            var course = testCourses.First();

            var result = await _controller.Create(course);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("List", redirectToActionResult.ActionName);
        }

        // Edit
        [Fact]
        public async Task Edit_ActionExecutes_ReturnsViewResultType()
        {
            var course = testCourses.First();
            _mockRepo.Setup(repo => repo.Courses.GetItem(1))
                .ReturnsAsync(course);

            var result = await _controller.Edit(1);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Edit_BadRequest_ReturnsNotFoundResponse()
        {
            var course = testCourses.First();
            _mockRepo.Setup(repo => repo.Courses.GetItem(1))
                .ReturnsAsync(course);

            var result = await _controller.Edit(2);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Edit_ActionExecutes_ReturnsRightItem()
        {
            var course = testCourses.First();
            _mockRepo.Setup(repo => repo.Courses.GetItem(1))
                .ReturnsAsync(course);

            var result = await _controller.Edit(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var testCourse = Assert.IsType<Course>(viewResult.Model);
            Assert.Equal(course.Id, testCourse.Id);
            Assert.Equal(course.Name, testCourse.Name);
        }

        [Fact]
        public async void Edit_InvalidModelState_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");
            var course = new Course { Id = 1 };

            var result = await _controller.Edit(1, course);

            var viewResult = Assert.IsType<ViewResult>(result);
            var testCourse = Assert.IsType<Course>(viewResult.Model);
            Assert.Equal(course.Id, testCourse.Id);
        }

        [Fact]
        public async Task Edit_InvalidModelState_EditCourseNeverExecutes()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");
            var course = new Course { Id = 1 };

            await _controller.Edit(1, course);

            _mockRepo.Verify(repo => repo.Courses.Add(It.IsAny<Course>()), Times.Never);
        }

        [Fact]
        public async Task Edit_ActionExecutes_DeleteCourseCalledOnce()
        {
            var course = testCourses.First();
            course.Name = "Operating System 2";
            _mockRepo.Setup(repo => repo.Courses.Update(It.IsAny<Course>()));

            await _controller.Edit(1, course);

            _mockRepo.Verify(repo => repo.Courses.Update(It.IsAny<Course>()), Times.Once);
        }

        [Fact]
        public async Task Edit_ActionExecuted_RedirectsToListAction()
        {
            var course = testCourses.First();
            course.Name = "Operating System 2";
            _mockRepo.Setup(repo => repo.Courses.Update(It.IsAny<Course>()));

            var result = await _controller.Edit(1, course);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("List", redirectToActionResult.ActionName);
        }

        // Delete
        [Fact]
        public async Task Delete_ActionExecutes_ReturnsViewResultType()
        {
            var course = testCourses.First();
            _mockRepo.Setup(repo => repo.Courses.GetItem(1))
                .ReturnsAsync(course);

            var result = await _controller.Delete(1);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Delete_BadRequest_ReturnsNotFoundResponse()
        {
            var course = testCourses.First();
            _mockRepo.Setup(repo => repo.Courses.GetItem(1))
                .ReturnsAsync(course);

            var result = await _controller.Delete(2);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ActionExecutes_ReturnsRightItem()
        {
            var course = testCourses.First();
            _mockRepo.Setup(repo => repo.Courses.GetItem(1))
                .ReturnsAsync(course);

            var result = await _controller.Delete(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var testCourse = Assert.IsType<Course>(viewResult.Model);
            Assert.Equal(course.Id, testCourse.Id);
            Assert.Equal(course.Name, testCourse.Name);
        }

        [Fact]
        public async Task DeleteConfirmed_ActionExecutes_DeleteCourseCalledOnce()
        {
            var course = testCourses.First();
            _mockRepo.Setup(repo => repo.Courses.GetItem(1))
                .ReturnsAsync(course);
            _mockRepo.Setup(repo => repo.Courses.Remove(It.IsAny<Course>()));

            await _controller.DeleteConfirmed(1);

            _mockRepo.Verify(repo => repo.Courses.Remove(It.IsAny<Course>()), Times.Once);
        }

        [Fact]
        public async Task DeleteConfirmed_ActionExecuted_RedirectsToListAction()
        {
            var course = testCourses.First();
            _mockRepo.Setup(repo => repo.Courses.GetItem(1))
                .ReturnsAsync(course);
            _mockRepo.Setup(repo => repo.Courses.Remove(It.IsAny<Course>()));

            var result = await _controller.DeleteConfirmed(1);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("List", redirectToActionResult.ActionName);
        }

        // Test test
        //[Fact]
        //public async void ListTest()
        //{
        //    // Arrange
        //    _mockRepo.Setup(r => r.Courses.GetList())
        //        .ReturnsAsync(testCourses);

        //    // Act
        //    Trace.WriteLine("Результат:");
        //    var result = await _controller.List();

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result); // является ли результат типом ViewResult
        //    var model = Assert.IsAssignableFrom<IEnumerable<Course>>(
        //        viewResult.ViewData.Model); // может ли viewResult.ViewData.Model быть заменён на тип IEnumerable<Course>
        //    Assert.Equal(3, model.Count()); // находится ли в GetTestCourseList() 3 записи
        //}
    }
}