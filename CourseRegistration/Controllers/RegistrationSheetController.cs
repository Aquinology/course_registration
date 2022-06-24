using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseRegistration.Interfaces;
using CourseRegistration.Models;

namespace CourseRegistration.Controllers
{
    public class RegistrationSheetController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public RegistrationSheetController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // Validator
        public IActionResult StudentsInCourseUnique(int courseid, int studentid)
        {
            return Json(_repository.RegistrationSheets.StudentsInCourseUnique(courseid, studentid));
        }

        // GET: RegistrationSheet
        public async Task<IActionResult> List(int courseid)
        {
            var courseName = await _repository.Courses.GetItem(courseid);
            ViewBag.CourseId = courseid;
            ViewBag.CourseName = courseName.Name;
            return _repository.RegistrationSheets != null ?
                        View(await _repository.RegistrationSheets.GetCourseStudentsList(courseid)) :
                        Problem("Entity set 'CourseRegistrationContext.RegistrationSheets'  is null.");
        }

        // GET: RegistrationSheet/Create
        public async Task<IActionResult> CreateAsync(int courseid)
        {
            ViewData["StudentId"] = new SelectList(await _repository.RegistrationSheets.GetAbsentStudentsList(courseid), "Id", "Name");
            ViewBag.CourseId = courseid;
            return View();
        }

        // POST: RegistrationSheet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,CourseId")] RegistrationSheet registrationSheet)
        {
            if (ModelState.IsValid)
            {
                _repository.RegistrationSheets.Add(registrationSheet);
                await _repository.Save();
                return RedirectToAction(nameof(List), new { courseid = registrationSheet.CourseId });
            }
            return View(registrationSheet);
        }

        // GET: RegistrationSheet/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var registrationSheet = await _repository.RegistrationSheets.GetRegistrationSheet(id);
            ViewBag.CourseId = registrationSheet.CourseId;
            return registrationSheet != null ? View(registrationSheet) : NotFound();
        }

        // POST: RegistrationSheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrationSheet = await _repository.RegistrationSheets.GetItem(id);
            _repository.RegistrationSheets.Remove(registrationSheet);
            await _repository.Save();
            return RedirectToAction(nameof(List), new { courseid = registrationSheet.CourseId });
        }
    }
}
