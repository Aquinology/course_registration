using CourseRegistration.Models;

namespace CourseRegistration.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        bool StudentIdIsUnique(int studentid);
    }
}
