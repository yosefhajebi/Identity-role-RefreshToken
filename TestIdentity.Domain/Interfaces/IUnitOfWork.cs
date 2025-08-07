namespace TestIdentity.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    IPermissionRepository Permissions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
