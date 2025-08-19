namespace TestIdentity.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    //IUserRepository Users { get; }
    //IRoleRepository Roles { get; }
    //IPermissionRepository Permissions { get; }
    //IResourceRepository Resources { get; }
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
