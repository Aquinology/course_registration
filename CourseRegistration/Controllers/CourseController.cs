using Microsoft.AspNetCore.Mvc;
using CourseRegistration.Interfaces;
using CourseRegistration.Models;

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
                        View(await _unitOfWork.Courses.GetAll()) :
                        Problem("Entity set 'CourseRegistrationContext.Courses'  is null.");
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name")] Course course)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Courses.Add(course);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
    }
}
