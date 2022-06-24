using CourseRegistration.Models;

namespace CourseRegistration.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        bool CourseNameIsUnique(string name);
    }
}
