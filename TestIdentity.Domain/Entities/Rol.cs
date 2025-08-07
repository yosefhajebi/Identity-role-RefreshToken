namespace TestIdentity.Domain.Entities;
using TestIdentity.Domain.Common;
public class Role:BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public List<RolePermission> RolePermissions { get; set; } = new();
    public List<User> Users { get; set; } = new();
}
