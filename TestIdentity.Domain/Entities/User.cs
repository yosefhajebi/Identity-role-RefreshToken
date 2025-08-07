namespace TestIdentity.Domain.Entities;

using TestIdentity.Domain.ValueObjects;
using TestIdentity.Domain.Common;
public class User:BaseEntity
{
    public string UserName { get; set; } = string.Empty;
    public Email Email { get; set; } = Email.Create("");
    public string PasswordHash { get; set; } = string.Empty;

    public List<Role> Roles { get; set; } = new();
    public List<RefreshToken> RefreshTokens { get; set; } = new();
}
