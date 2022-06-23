using Microsoft.AspNetCore.Mvc;
using CourseRegistration.Interfaces;

namespace CourseRegistration.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return _unitOfWork.Courses != null ?
                        View(_unitOfWork.Courses.GetAll()) :
                        Problem("Entity set 'CourseRegistrationContext.Courses'  is null.");
        }

    }
}
