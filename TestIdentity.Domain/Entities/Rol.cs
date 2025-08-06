using TestIdentity.Domain.Common;

namespace TestIdentity.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; private set; }

    public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();

    public Role(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Role name cannot be empty.");

        Name = name;
    }
}
