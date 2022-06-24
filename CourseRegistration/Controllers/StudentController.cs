using Microsoft.AspNetCore.Mvc;
using CourseRegistration.Interfaces;
using CourseRegistration.Models;

namespace CourseRegistration.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public StudentController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // Validator
        public IActionResult StudentIdUnique(int studentid)
        {
            return Json(_repository.Students.StudentIdIsUnique(studentid));
        }

        // GET: Students
        public async Task<IActionResult> List()
        {
            return _repository.Students != null ?
                        View(await _repository.Students.GetList()) :
                        Problem("Entity set 'CourseRegistrationContext.Students'  is null.");
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StudentId,Group")] Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.Students.Add(student);
                await _repository.Save();
                return RedirectToAction(nameof(List));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _repository.Students.GetItem(id);
            return student != null ? View(student) : NotFound();
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StudentId,Group")] Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.Students.Update(student);
                await _repository.Save();
                return RedirectToAction(nameof(List));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _repository.Students.GetItem(id);
            return student != null ? View(student) : NotFound();
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _repository.Students.GetItem(id);
            _repository.Students.Remove(student);
            await _repository.Save();
            return RedirectToAction(nameof(List));
        }
    }
}
