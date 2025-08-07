// namespace TestIdentity.Domain.Entities;

// public class Permission
// {
//     public Guid Id { get; set; } = Guid.NewGuid();
//     public string Action { get; set; } = string.Empty; // مثلاً "Read", "Write", "Delete"
//     public Guid ResourceId { get; set; }

//     public Resource? Resource { get; set; }
//     public List<RolePermission> RolePermissions { get; set; } = new();
// }
namespace TestIdentity.Domain.Entities;
using TestIdentity.Domain.Common;
using TestIdentity.Domain.Enums;

public class Permission:BaseEntity
{
    public string Action { get; private set; } = string.Empty;
    public Guid ResourceId { get; private set; }

    public Resource? Resource { get; private set; }
    public List<RolePermission> RolePermissions { get; private set; } = new();

    private Permission() { }

    // public static Permission Create(string action, Guid resourceId)
    // {
    //     if (string.IsNullOrWhiteSpace(action))
    //         throw new ArgumentException("عمل مجوز نمی‌تواند خالی باشد.");

    //     if (resourceId == Guid.Empty)
    //         throw new ArgumentException("شناسه منبع معتبر نیست.");

    //     return new Permission
    //     {
    //         Id = Guid.NewGuid(),
    //         Action = action.Trim(),
    //         ResourceId = resourceId
    //     };
    // }
     public static Permission Create(Resource resource, PermissionAction action)
    {
        if (resource == null)
            throw new ArgumentNullException(nameof(resource), "منبع نمی‌تواند null باشد.");

        return new Permission
        {
            Id = Guid.NewGuid(),
            Action = action.ToString(), 
            ResourceId = resource.Id,
            Resource = resource
        };
    }

    public void AssignResource(Resource resource)
    {
        if (resource == null || resource.Id != ResourceId)
            throw new InvalidOperationException("منبع نامعتبر است.");

        Resource = resource;
    }
}

