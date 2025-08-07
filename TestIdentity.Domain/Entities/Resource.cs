namespace TestIdentity.Domain.Entities;
using TestIdentity.Domain.Common;
public class Resource:BaseEntity
{
    public string Name { get; set; } = string.Empty; // مثلاً "User", "Product", "Order"

    public List<Permission> Permissions { get; set; } = new();
}
