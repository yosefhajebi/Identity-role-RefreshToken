using Microsoft.EntityFrameworkCore;
using TestIdentity.Domain.Entities;
using TestIdentity.Application.Interfaces;
using TestIdentity.Infrastructure.Persistence;
using TestIdentity.Domain.Interfaces;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .Include(u => u.Roles)
            .ToListAsync();
    }

    public async Task<User> AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(User entity)
    {
        var user = await _context.Users.FindAsync(entity);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<bool> IsEmailTakenAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email.Value == email);
    }
    
    public void Update(User entity)
    {
         _context.Users.Update(entity);
         _context.SaveChangesAsync();
    }

    public void Remove(User entity)
    {
        var user =  _context.Users.Find(entity);
        if (user != null)
        {
            _context.Users.Remove(user);
             _context.SaveChangesAsync();
        }
    }
}
