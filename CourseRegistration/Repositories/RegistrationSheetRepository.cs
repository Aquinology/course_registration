using Microsoft.EntityFrameworkCore;
using CourseRegistration.Data;
using CourseRegistration.Interfaces;
using CourseRegistration.Models;

namespace CourseRegistration.Repositories
{
    public class RegistrationSheetRepository : GenericRepository<RegistrationSheet>, IRegistrationSheetRepository
    {
        public RegistrationSheetRepository(CourseRegistrationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RegistrationSheet>> GetCourseStudentsList(int courseid)
        {
            return await _context.RegistrationSheets.Include(s => s.Student).Where(s => s.CourseId == courseid).ToListAsync();
        }

        public bool StudentsInCourseUnique(int courseid, int studentid)
        {
            return !(_context.RegistrationSheets?.Any(s => s.CourseId == courseid && s.StudentId == studentid)).GetValueOrDefault();
        }

        public async Task<IEnumerable<Student>> GetAbsentStudentsList(int courseid)
        {
            var students = await _context.RegistrationSheets.Where(s => s.CourseId == courseid).Select(x => x.StudentId).ToListAsync();
            return _context.Students.Where(x => !students.Contains(x.Id));
        }

        public async Task<RegistrationSheet> GetRegistrationSheet(int id)
        {
            return await _context.RegistrationSheets.Include(s => s.Course).Include(s => s.Student).FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
