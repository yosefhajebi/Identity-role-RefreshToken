namespace TestIdentity.Application.DTOs;

public class PermissionDto
{
    public Guid Id { get; set; }
    public string Resource { get; set; } = default!;
    public string Action { get; set; } = default!;
}
