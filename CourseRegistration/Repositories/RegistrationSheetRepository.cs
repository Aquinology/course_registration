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

        public async Task<IEnumerable<RegistrationSheet>> GetCourseStudents(int courseid)
        {
            return await _context.RegistrationSheets.Where(s => s.CourseId == courseid).ToListAsync();
        }
    }
}
