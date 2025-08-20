using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestIdentity.Domain.Interfaces;
public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    // public async Task<IEnumerable<TEntity>> GetAllAsync()
    // {
    //     return await _dbSet.ToListAsync();
    // }
    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        IQueryable<TEntity> query = _dbSet;

        if (predicate != null)
            query = query.Where(predicate);

        return await query.ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        IQueryable<TEntity> query = _dbSet;

        if (predicate != null)
            query = query.Where(predicate);

        return await query.AnyAsync();
    }
    public IQueryable<TEntity> AsQueryable() => _dbSet.AsQueryable();
     
}