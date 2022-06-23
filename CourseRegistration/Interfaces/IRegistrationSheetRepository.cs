using CourseRegistration.Models;

namespace CourseRegistration.Interfaces
{
    public interface IRegistrationSheetRepository : IGenericRepository<RegistrationSheet>
    {
        Task<IEnumerable<RegistrationSheet>> GetCourseStudents(int courseid);
    }
}
