using TestIdentity.Application.DTOs;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Domain.Entities;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Http.Features;

namespace TestIdentity.Application.Services;

public class UserService : BaseService<User, RegisterRequest, UpdateUserRequest, UserDto>, IUserService
{
    protected readonly IUserRepository _repository;
    public UserService(
        IUnitOfWork unitOfWork,
        ILogger<BaseService<User, RegisterRequest, UpdateUserRequest, UserDto>> logger,
        IMapper mapper,
        IUserRepository userRepository) : base(unitOfWork, logger, mapper)
    {
         _repository = userRepository;
    }
    public async Task<User?> GetByUsernameAsync(string userName)
    {
        List<User> users = (List<User>)await _repository.GetAllAsync(It => It.Username == userName);
        if (users.Count() == 1)
        {
            return users.First();
        }
        else
        {
            return null;
        }
        
    }
    public override async Task CreateAsync(RegisterRequest dto)
    {
         await base.CreateAsync(dto);
    }
    public async Task<bool> IsEmailTakenAsync(string email)
    {
         return await _repository.AnyAsync(u => u.Email.Value == email);
    }
}
