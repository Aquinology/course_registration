using CourseRegistration.Data;
using CourseRegistration.Interfaces;
using CourseRegistration.Models;

namespace CourseRegistration.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(CourseRegistrationContext context) : base(context)
        {
        }
    }
}
