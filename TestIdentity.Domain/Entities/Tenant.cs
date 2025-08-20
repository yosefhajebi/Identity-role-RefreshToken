namespace TestIdentity.Domain.Entities;
public class Tenant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ConnectionString { get; set; }
    public bool IsActive { get; set; }
}
