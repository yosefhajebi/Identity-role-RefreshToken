using TestIdentity.Domain.Common;
using TestIdentity.Domain.ValueObjects;

namespace TestIdentity.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }

    public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
    public ICollection<RefreshToken>? RefreshTokens { get; set; }

    public User(string username, Email email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be empty.");

        Username = username;
        Email = email;
        PasswordHash = passwordHash;
    }

    public void ChangePassword(string newHash)
    {
        PasswordHash = newHash;
    }

    public void AssignRole(Role role)
    {
        if (!UserRoles.Any(ur => ur.RoleId == role.Id))
            UserRoles.Add(new UserRole(Id, role.Id));
    }

    public bool HasRole(string roleName)
    {
        return UserRoles.Any(ur => ur.Role?.Name == roleName);
    }
}
