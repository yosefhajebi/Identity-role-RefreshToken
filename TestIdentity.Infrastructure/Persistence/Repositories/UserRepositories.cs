using Microsoft.EntityFrameworkCore;
using TestIdentity.Domain.Entities;
using TestIdentity.Domain.Interfaces;

public class UserRepository :GenericRepository<User>, IUserRepository
{
    protected readonly DbSet<User> _dbSet;
    public UserRepository(DbContext context) : base(context)
    {
       _dbSet = context.Set<User>();
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbSet
             .Include(u => u.Roles)
             .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<bool> IsEmailTakenAsync(string email)
    {
        return await _dbSet.AnyAsync(u => u.Email.Value == email);
    }
}
