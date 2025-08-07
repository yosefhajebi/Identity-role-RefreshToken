using TestIdentity.Domain.Interfaces;
namespace TestIdentity.Infrastructure.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IUserRepository Users { get; }
    public IRoleRepository Roles { get; }
    public IPermissionRepository Permissions { get; }

    public UnitOfWork(
        AppDbContext context,
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IPermissionRepository permissionRepository)
    {
        _context = context;
        Users = userRepository;
        Roles = roleRepository;
        Permissions = permissionRepository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
