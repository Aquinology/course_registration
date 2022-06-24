using CourseRegistration.Data;
using CourseRegistration.Interfaces;

namespace CourseRegistration.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly CourseRegistrationContext _context;

        public ICourseRepository Courses { get; private set; }
        public IStudentRepository Students { get; private set; }
        public IRegistrationSheetRepository RegistrationSheets { get; private set; }

        public RepositoryWrapper(CourseRegistrationContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Students = new StudentRepository(_context);
            RegistrationSheets = new RegistrationSheetRepository(_context);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
