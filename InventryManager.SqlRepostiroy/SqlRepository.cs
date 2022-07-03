using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventryManager.SqlRepostiroy
{
    public class SqlRepository<T> : ISqlRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        
        public SqlRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(params object[] keys)
        {
            var entity = _dbSet.Find(keys);
            if (entity == null)
                throw new InvalidOperationException("Not Found");
            _dbSet.Remove(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var existing = await _dbSet.FindAsync(entity.Id);
            if (existing != null)
            {
                existing.ModifiedDate = DateTime.UtcNow;
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.Entry(existing).Property("AddedDate").IsModified = false;
            }
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}