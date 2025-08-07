namespace TestIdentity.Application.DTOs;

public class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public List<string> Permissions { get; set; } = new();
}
