using Microsoft.EntityFrameworkCore;
using TestIdentity.Domain.Entities;
using TestIdentity.Infrastructure.Persistence;
using TestIdentity.Domain.Interfaces;
namespace TestIdentity.Infrastructure.Persistence.Repositories;
  

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    
    protected readonly DbSet<Role> _dbSet;

    public RoleRepository(AppDbContext context):base(context)
    {
        _dbSet = context.Roles;
    }
    public async Task<Role?> GetByNameAsync(string roleName)
    {
        return await _dbSet
            .Include(r => r.Permissions)
            .FirstOrDefaultAsync(r => r.Name == roleName);
    }
}
