using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CourseRegistration.Data;
using CourseRegistration.Interfaces;


namespace CourseRegistration.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CourseRegistrationContext _context;

        public GenericRepository(CourseRegistrationContext context)
        {
            _context = context;
        }

        public async Task<T> GetItem(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetList()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindList(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
