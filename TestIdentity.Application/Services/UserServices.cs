using TestIdentity.Application.DTOs;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Domain.Entities;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using TestIdentity.Application.DTOs.Role;

namespace TestIdentity.Application.Services;

public class UserService : BaseService<User, RegisterRequest, UpdateUserRequest, UserDto>, IUserService
{
    protected readonly IRepository<User> _userRepository;
    public UserService(
        IUnitOfWork unitOfWork,
        ILogger<BaseService<User, RegisterRequest, UpdateUserRequest, UserDto>> logger,
        IMapper mapper//,
                      //IUserRepository userRepository
        ) : base(unitOfWork, logger, mapper)
    {
        _userRepository = unitOfWork.GetRepository<User>();
    }
    public async Task<User?> GetByUsernameAsync(string userName)
    {
        List<User> users = (List<User>)await _userRepository.GetAllAsync(It => It.Username == userName);
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
        //return await _userRepository.AnyAsync(u => u.Email.Value == email);        
        return await _unitOfWork.Users.IsEmailTakenAsync(email);
    }
    public async Task<IEnumerable<RoleDto>> GetUserRolById(Guid userId)
    {
        var roles = await _unitOfWork.Users.GetUserRolById(userId);        
        return _mapper.Map<IEnumerable<RoleDto>>(roles);
    }
}
