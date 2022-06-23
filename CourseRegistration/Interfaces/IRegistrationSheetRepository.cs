using CourseRegistration.Models;

namespace CourseRegistration.Interfaces
{
    public interface IRegistrationSheetRepository : IGenericRepository<RegistrationSheet>
    {
        IEnumerable<RegistrationSheet> GetCourseStudents(int courseid);
    }
}
