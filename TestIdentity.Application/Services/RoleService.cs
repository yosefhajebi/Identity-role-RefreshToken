using TestIdentity.Application.DTOs;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Entities;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Application.Exceptions;

namespace TestIdentity.Application.Services;

public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RoleDto>> GetAllAsync()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();
        return roles.Select(r => new RoleDto
        {
            Id = r.Id,
            Name = r.Name,
            Permissions = r.Permissions.Select(p => $"{p.Resource}:{p.Action}").ToList()
        });
    }

    public async Task<RoleDto?> GetByIdAsync(Guid id)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(id);
        if (role == null) return null;

        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Permissions = role.Permissions.Select(p => $"{p.Resource}:{p.Action}").ToList()
        };
    }

    public async Task CreateAsync(RoleDto dto)
    {
        var role = Role.Create(dto.Name);
        await _unitOfWork.Roles.AddAsync(role);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, RoleDto dto)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(id);
        if (role == null)
            throw new NotFoundException("نقش یافت نشد.");

        role.UpdateName(dto.Name);
        _unitOfWork.Roles.Update(role);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(id);
        if (role == null) return;

        _unitOfWork.Roles.Remove(role);
        await _unitOfWork.SaveChangesAsync();
    }
}
