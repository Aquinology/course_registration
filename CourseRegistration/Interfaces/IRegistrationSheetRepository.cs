using CourseRegistration.Models;

namespace CourseRegistration.Interfaces
{
    public interface IRegistrationSheetRepository : IGenericRepository<RegistrationSheet>
    {
        Task<IEnumerable<RegistrationSheet>> GetCourseStudentsList(int courseid);
        bool StudentsInCourseUnique(int courseid, int studentid);
        Task<IEnumerable<Student>> GetAbsentStudentsList(int courseid);
        Task<RegistrationSheet> GetRegistrationSheet(int id);
    }
}
