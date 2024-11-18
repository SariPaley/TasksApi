using Microsoft.EntityFrameworkCore;
using TasksApi.Models;

namespace TasksApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly TasksDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(TasksDbContext tasksDbContext)
        {
            _context = tasksDbContext;
            _dbSet = tasksDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();
        public T GetById(int id) => _dbSet.Find(id);
        public void Add(T entity) { _dbSet.Add(entity); _context.SaveChanges(); }
        public void Update(T entity) { _context.Entry(entity).State = EntityState.Modified; _context.SaveChanges(); }
        public void Delete(int id) { var entity = GetById(id); if (entity != null) _dbSet.Remove(entity); _context.SaveChanges(); }
    }
}
