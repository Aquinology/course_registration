namespace CourseRegistration.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }
        IRegistrationSheetRepository RegistrationSheets { get; }
        Task Save();
    }
}
