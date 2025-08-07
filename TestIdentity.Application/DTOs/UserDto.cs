namespace TestIdentity.Application.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public List<string> Roles { get; set; } = new();
}
