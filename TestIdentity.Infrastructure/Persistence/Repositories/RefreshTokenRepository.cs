using Microsoft.EntityFrameworkCore;
using TestIdentity.Domain.Entities;
using TestIdentity.Domain.Interfaces;


namespace TestIdentity.Infrastructure.Persistence.Repositories;
public class RefreshTokenRepository : IRefreshTokenRepository
{
   private readonly AppDbContext _context;

    public RefreshTokenRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token) =>
        await _context.RefreshTokens.FirstOrDefaultAsync(r => r.Token == token);

    public async Task AddAsync(RefreshToken token)
    {
        await _context.RefreshTokens.AddAsync(token);
        await _context.SaveChangesAsync();
    }

    public async Task RevokeAsync(string token)
    {
        var existing = await GetByTokenAsync(token);
        if (existing != null)
        {
            existing.IsRevoked = true;
            await _context.SaveChangesAsync();
        }
    }
}
