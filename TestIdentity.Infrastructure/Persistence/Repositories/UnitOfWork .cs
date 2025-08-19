using TestIdentity.Domain.Interfaces;
namespace TestIdentity.Infrastructure.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    //public IUserRepository Users { get; }
    //public IRoleRepository Roles { get; }
    //public IPermissionRepository Permissions { get; }
    //public IResourceRepository Resources { get; }
    private readonly Dictionary<Type, object> _repositories = new();
    public UnitOfWork(
        AppDbContext context//,
        //IUserRepository userRepository,
        //IRoleRepository roleRepository,
        ///IPermissionRepository permissionRepository,
        //IResourceRepository resourceRepository
        )
    {
        _context = context;
        //Users = userRepository;
        //Roles = roleRepository;
        //Permissions = permissionRepository;
        //Resources = resourceRepository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity);

        if (!_repositories.ContainsKey(type))
        {
            var repositoryInstance = new GenericRepository<TEntity>(_context);
            _repositories[type] = repositoryInstance;
        }

        return (IRepository<TEntity>)_repositories[type];
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
