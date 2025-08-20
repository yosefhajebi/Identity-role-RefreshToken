// using Microsoft.EntityFrameworkCore;
// using TestIdentity.Domain.Entities;
// using TestIdentity.Infrastructure.Persistence;
// using TestIdentity.Domain.Interfaces;
// namespace TestIdentity.Infrastructure.Persistence.Repositories;
// public class PermissionRepository : IPermissionRepository
// {
//     private readonly AppDbContext _context;

//     public PermissionRepository(AppDbContext context)
//     {
//         _context = context;
//     }
//      public async Task<Permission?> GetByIdAsync(Guid id)
//      {
//          return await _context.Permissions
//              .Include(p => p.Resource)
//              .Include(p => p.RolePermissions)
//              .FirstOrDefaultAsync(p => p.Id == id);
//      }

//      public async Task<IEnumerable<Permission>> GetAllAsync()
//      {
//          return await _context.Permissions
//              .Include(p => p.Resource)
//              .Include(p => p.RolePermissions)
//              .ToListAsync();
//      }

//     public async Task<Permission> AddAsync(Permission permission)
//     {
//         _context.Permissions.Add(permission);
//         await _context.SaveChangesAsync();
//         return permission;
//      }
     
//     public async Task<IEnumerable<Permission>> GetByRoleIdAsync(Guid roleId)
//     {
//         return await _context.Permissions
//             .Include(p => p.RolePermissions)
//             .Where(p => p.RolePermissions.Any(rp => rp.RoleId == roleId))
//             .ToListAsync();
//     }

//     public async Task UpdateAsync(Permission entity)
//     {
//         _context.Permissions.Update(entity);
//          await _context.SaveChangesAsync();
//     }

//     public async Task RemoveAsync(Permission entity)
//     {
//         var permission = await _context.Permissions.FindAsync(entity);
//          if (permission != null)
//          {
//              _context.Permissions.Remove(permission);
//              await _context.SaveChangesAsync();
//          }
//     }

//     public void Update(Permission entity)
//     {
//          _context.Permissions.Update(entity);
//          _context.SaveChangesAsync();
//     }

//     public void Remove(Permission entity)
//     {
//         var permission =  _context.Permissions.FirstOrDefault(entity);
//          if (permission != null)
//          {
//              _context.Permissions.Remove(permission);
//               _context.SaveChangesAsync();
//          }
//     }
// }
