using Microsoft.EntityFrameworkCore;
using TestIdentity.Domain.Entities;
using TestIdentity.Infrastructure.Persistence;
using TestIdentity.Domain.Interfaces;
namespace TestIdentity.Infrastructure.Persistence.Repositories;
  

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Role?> GetByIdAsync(Guid id)
    {
        return await _context.Roles
            .Include(r => r.Permissions)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _context.Roles
            .Include(r => r.Permissions)
            .ToListAsync();
    }

    public async Task<Role> AddAsync(Role role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return role;
    }

    public async Task UpdateAsync(Role role)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Role entity)
    {
        var role = await _context.Roles.FindAsync(entity);
        if (role != null)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Role?> GetByNameAsync(string roleName)
    {
        return await _context.Roles
            .Include(r => r.Permissions)
            .FirstOrDefaultAsync(r => r.Name == roleName);
    }


    public void Update(Role entity)
    {
         _context.Roles.Update(entity);
         _context.SaveChangesAsync();
    }

    public void Remove(Role entity)
    {
        var role =  _context.Roles.Find(entity);
        if (role != null)
        {
            _context.Roles.Remove(role);
             _context.SaveChangesAsync();
        }
    }

    // Task<IEnumerable<Role>> IRepository<Role>.GetAllAsync()
    // {
    //     throw new NotImplementedException();
    // }
    //  public async Task<IEnumerable<Role>> GetAllAsync()
    //  {
    //      return await _context.Roles
    //          .Include(p => p.Permissions)
    //          .ToListAsync();
    //  }

    // Task IRepository<Role>.AddAsync(Role entity)
    // {
    //     return AddAsync(entity);
    // }

    // public Task RemoveAsync(Role entity)
    // {
    //     throw new NotImplementedException();
    // }
}
