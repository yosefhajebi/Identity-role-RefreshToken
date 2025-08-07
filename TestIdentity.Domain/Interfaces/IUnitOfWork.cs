namespace TestIdentity.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    IPermissionRepository Permissions { get; }
    IResourceRepository Resources { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
