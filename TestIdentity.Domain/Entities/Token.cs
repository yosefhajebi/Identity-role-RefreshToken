namespace TestIdentity.Domain.Entities
{
    public class Token
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Value { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ExpiresAt { get; set; }
        public Guid UserId { get; set; }
    }
}
