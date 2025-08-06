namespace TestIdentity.Domain.Entities;

public class UserRole
{
    public Guid UserId { get; private set; }
    public User? User { get; set; }

    public Guid RoleId { get; private set; }
    public Role? Role { get; set; }

    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}
