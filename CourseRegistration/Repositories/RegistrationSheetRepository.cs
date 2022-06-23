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

        public IEnumerable<RegistrationSheet> GetCourseStudents(int courseid)
        {
            return _context.RegistrationSheets.Where(s => s.CourseId == courseid).ToList();
        }
    }
}
