using Microsoft.EntityFrameworkCore;
using TestIdentity.Domain.Entities;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Infrastructure.Persistence;

public class UserRepository :GenericRepository<User>, IUserRepository
{
    protected readonly DbSet<User> _dbSet;
    public UserRepository(AppDbContext context) : base(context)
    {
       _dbSet = context.Users;
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
    public async Task<IEnumerable<Role>> GetUserRolById(Guid userId)
    {        
        return await _dbSet.Where(u => u.Id == userId).SelectMany(u => u.Roles).ToListAsync();        
    }
  
}
