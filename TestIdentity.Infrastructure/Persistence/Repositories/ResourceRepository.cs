// using Microsoft.EntityFrameworkCore;
// using TestIdentity.Domain.Entities;
// using TestIdentity.Application.Interfaces;
// using TestIdentity.Infrastructure.Persistence;
// using TestIdentity.Domain.Interfaces;

// namespace TestIdentity.Infrastructure.Persistence.Repositories;
// public class ResourceRepository : IResourceRepository
// {
//     private readonly AppDbContext _context;

//     public ResourceRepository(AppDbContext context)
//     {
//         _context = context;
//     }

//     public async Task<Resource?> GetByNameAsync(string name)
//     {
//         return await _context.Resources
//             .Include(r => r.Permissions)
//             .FirstOrDefaultAsync(r => r.Name == name);
//     }

//     public async Task<Resource> AddAsync(Resource resource)
//     {
//         _context.Resources.Add(resource);
//         await _context.SaveChangesAsync();
//         return resource;
//     }

//     public async Task<IEnumerable<Resource>> GetAllAsync()
//     {
//         return await _context.Resources
//             .Include(r => r.Permissions)
//             .ToListAsync();
//     }

//     public async Task<Resource?> GetByIdAsync(Guid id)
//     {
//         return await _context.Resources
//             .Include(r => r.Permissions)
//             .FirstOrDefaultAsync(r => r.Id == id);
//     }  

//     public async Task RemoveAsync(Resource entity)
//     {
//         var resource = await _context.Resources.FindAsync(entity);
//         if (resource != null)
//         {
//             _context.Resources.Remove(resource);
//             await _context.SaveChangesAsync();
//         }
//     }
//     public void Update(Resource entity)
//     {
//           _context.Resources.Update(entity);
//          _context.SaveChangesAsync();
//     }

//     public void Remove(Resource entity)
//     {
//         var resource = _context.Resources.Find(entity);
//         if (resource != null)
//         {
//             _context.Resources.Remove(resource);
//              _context.SaveChangesAsync();
//         }
//     }

//     public async Task UpdateAsync(Resource entity)
//     {
//         _context.Resources.Update(entity);
//          await _context.SaveChangesAsync();
//     }
// }
