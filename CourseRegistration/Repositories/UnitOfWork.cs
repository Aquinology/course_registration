using CourseRegistration.Data;
using CourseRegistration.Interfaces;

namespace CourseRegistration.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CourseRegistrationContext _context;

        public UnitOfWork(CourseRegistrationContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Students = new StudentRepository(_context);
            RegistrationSheets = new RegistrationSheetRepository(_context);
        }

        public ICourseRepository Courses { get; private set; }
        public IStudentRepository Students { get; private set; }
        public IRegistrationSheetRepository RegistrationSheets { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
