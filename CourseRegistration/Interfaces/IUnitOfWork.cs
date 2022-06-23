namespace CourseRegistration.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }
        IRegistrationSheetRepository RegistrationSheets { get; }
        Task Complete();
    }
}
