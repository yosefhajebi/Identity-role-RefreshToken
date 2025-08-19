namespace TestIdentity.Application.DTOs;

public class UpdateUserRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public List<string> Roles { get; set; } = new();
}
