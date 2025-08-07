using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestIdentity.Application.Interfaces;
using TestIdentity.Application.Services;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Infrastructure.Persistence;
using TestIdentity.Infrastructure.Persistence.Repositories;

namespace TestIdentity.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IResourceRepository, ResourceRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<TestIdentity.Domain.Interfaces.ITokenService, TestIdentity.Infrastructure.Persistence.Repositories.TokenService>();

        // services.AddScoped<IAuthService, AuthService>();
        // services.AddScoped<IUserService, UserService>();
        
        
        

        return services;
    }
}
