using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Repository.Repositories.Implementations
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;
        private bool _disposed = false;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await _entities.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _entities.Remove(entity);
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> expression)
        {
            var data = await _entities.Where(expression).AsNoTracking().ToListAsync();

            return data;
        }

        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            T entity = await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id)
                        ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");

            return entity;
        }

        public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null) throw new NullReferenceException();

            _entities.Update(entity);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
        }
    }
}
