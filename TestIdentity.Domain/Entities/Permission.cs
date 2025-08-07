namespace TestIdentity.Domain.Entities;

public class Permission
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Action { get; set; } = string.Empty; // مثلاً "Read", "Write", "Delete"
    public Guid ResourceId { get; set; }

    public Resource? Resource { get; set; }
    public List<RolePermission> RolePermissions { get; set; } = new();
}
