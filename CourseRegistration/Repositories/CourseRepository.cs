using CourseRegistration.Data;
using CourseRegistration.Interfaces;
using CourseRegistration.Models;

namespace CourseRegistration.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(CourseRegistrationContext context) : base(context)
        {
        }
    }
}
