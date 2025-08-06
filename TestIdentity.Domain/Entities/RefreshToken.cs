using TestIdentity.Domain.Common;

namespace TestIdentity.Domain.Entities;
public class RefreshToken:BaseEntity
{    
    public string Token { get; set; } = string.Empty;
    public DateTime Expires { get; set; }
    public bool IsRevoked { get; set; } = false;
    public string UserId { get; set; } = string.Empty;
    public User? User { get; set; }
}
