using TestIdentity.Application.DTOs;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Entities;
using TestIdentity.Domain.Enums;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Application.Exceptions;

namespace TestIdentity.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IResourceRepository _resourceRepository;

    public PermissionService(IUnitOfWork unitOfWork, IResourceRepository resourceRepository)
    {
        _unitOfWork = unitOfWork;
        _resourceRepository = resourceRepository;
    }

    public async Task<IEnumerable<PermissionDto>> GetAllAsync()
    {
        var permissions = await _unitOfWork.Permissions.GetAllAsync();
        return permissions.Select(p => new PermissionDto
        {
            Id = p.Id,
            Resource = p.Resource.Name,
            Action = p.Action.ToString()
        });
    }

    public async Task<IEnumerable<PermissionDto>> GetByRoleIdAsync(Guid roleId)
    {
        var permissions = await _unitOfWork.Permissions.GetByRoleIdAsync(roleId);
        return permissions.Select(p => new PermissionDto
        {
            Id = p.Id,
            Resource = p.Resource.Name,
            Action = p.Action.ToString()
        });
    }

    public async Task AddPermissionToRoleAsync(Guid roleId, PermissionDto dto)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(roleId);
        if (role == null)
            throw new NotFoundException("نقش یافت نشد.");
        var resource = await _resourceRepository.GetByNameAsync(dto.Resource);
        if (resource == null)
            throw new Exception("منبع یافت نشد.");
        var permission = Permission.Create(resource, Enum.Parse<PermissionAction>(dto.Action));
        role.AddPermission(permission);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemovePermissionFromRoleAsync(Guid roleId, Guid permissionId)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(roleId);
        if (role == null)
            throw new NotFoundException("نقش یافت نشد.");

        role.RemovePermission(permissionId);
        await _unitOfWork.SaveChangesAsync();
    }
}
