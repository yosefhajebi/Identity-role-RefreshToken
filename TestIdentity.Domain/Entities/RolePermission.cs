namespace TestIdentity.Domain.Entities;
using TestIdentity.Domain.Common;
public class RolePermission:BaseEntity
{

    public Guid RoleId { get; set; }
    public Role? Role { get; set; }

    public Guid PermissionId { get; set; }
    public Permission? Permission { get; set; }
}
