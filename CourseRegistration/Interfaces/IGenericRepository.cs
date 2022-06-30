using System.Linq.Expressions;

namespace CourseRegistration.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> GetItem(int id);
        Task<IEnumerable<T>> GetList();
        Task<IEnumerable<T>> FindList(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
