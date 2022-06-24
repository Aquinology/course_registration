using Microsoft.AspNetCore.Mvc;
using CourseRegistration.Interfaces;
using CourseRegistration.Models;

namespace CourseRegistration.Controllers
{
    public class CourseController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public CourseController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // Validator
        public IActionResult CourseNameUnique(string name)
        {
            return Json(_repository.Courses.CourseNameIsUnique(name));
        }

        // GET: Courses
        public async Task<IActionResult> List()
        {
            return _repository.Courses != null ?
                        View(await _repository.Courses.GetList()) :
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
                _repository.Courses.Add(course);
                await _repository.Save();
                return RedirectToAction(nameof(List));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _repository.Courses.GetItem(id);
            return course != null ? View(course) : NotFound();
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Course course)
        {
            if (ModelState.IsValid)
            {
                _repository.Courses.Update(course);
                await _repository.Save();
                return RedirectToAction(nameof(List));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _repository.Courses.GetItem(id);
            return course != null ? View(course) : NotFound();
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _repository.Courses.GetItem(id);
            _repository.Courses.Remove(course);
            await _repository.Save();
            return RedirectToAction(nameof(List));
        }
    }
}
