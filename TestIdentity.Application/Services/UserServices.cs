using TestIdentity.Application.DTOs;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Domain.ValueObjects;
using TestIdentity.Domain.Entities;
using TestIdentity.Application.Exceptions;

namespace TestIdentity.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            FullName = u.FullName.ToString(),
            Email = u.Email.ToString(),
            Roles = u.Roles.Select(r => r.Name).ToList()
        });
    }

    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            FullName = user.FullName.ToString(),
            Email = user.Email.ToString(),
            Roles = user.Roles.Select(r => r.Name).ToList()
        };
    }

    public async Task CreateAsync(RegisterRequest request)
    {
        var user = User.Create(
            FullName.Create(request.FirstName, request.LastName),
            Email.Create(request.Email),
            Password.Create(request.Password)
        );

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateUserRequest request)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null)
            throw new NotFoundException("کاربر یافت نشد.");

        user.UpdateFullName(FullName.Create(request.FirstName, request.LastName));
        user.UpdateRoles(request.Roles); // فرض بر اینه که متدی برای این کار در کلاس User وجود داره

        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null) return;

        _unitOfWork.Users.Remove(user);
        await _unitOfWork.SaveChangesAsync();
    }
}
