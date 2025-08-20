using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Infrastructure.Persistence;
using TestIdentity.Application.Services;
using TestIdentity.Domain.Entities;
using TestIdentity.Application.DTOs;

namespace TestIdentity.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));      

        // ثبت ریپازیتوری‌ها
        services.Scan(scan => scan
            .FromAssemblyOf<GenericRepository<User>>() // یا هر کلاس مرجع در Infrastructure
            .AddClasses(c => c.AssignableTo(typeof(IRepository<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        // ثبت سرویس‌های generic
        services.Scan(scan => scan
            .FromAssemblyOf<BaseService<User, RegisterUserRequest, UpdateUserRequest, UserDto>>() // فقط برای تعیین مسیر اسمبلی
            .AddClasses(c => c.AssignableTo(typeof(IService<,,,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
