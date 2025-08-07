namespace TestIdentity.Domain.Entities;

public class Role
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public List<Permission> Permissions { get; private set; } = new();

    private Role() { }

    public static Role Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("نام نقش نمی‌تواند خالی باشد.");

        return new Role
        {
            Id = Guid.NewGuid(),
            Name = name.Trim()
        };
    }

    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("نام جدید نقش معتبر نیست.");

        Name = newName.Trim();
    }

    public void AddPermission(Permission permission)
    {
        if (!Permissions.Any(p => p.Id == permission.Id))
            Permissions.Add(permission);
    }

    public void RemovePermission(Guid permissionId)
    {
        var permission = Permissions.FirstOrDefault(p => p.Id == permissionId);
        if (permission != null)
            Permissions.Remove(permission);
    }
}
