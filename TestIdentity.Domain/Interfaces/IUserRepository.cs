using TestIdentity.Domain.Entities;

namespace TestIdentity.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
    Task<bool> IsEmailTakenAsync(string email);
    Task<IEnumerable<Role>> GetUserRolById(Guid userId);
}
