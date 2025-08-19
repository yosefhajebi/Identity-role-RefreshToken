using TestIdentity.Application.DTOs;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Domain.Entities;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace TestIdentity.Application.Services;

public class UserService : BaseService<User,RegisterRequest,UpdateUserRequest,UserDto>,IUserService
{
    public UserService(
        IUnitOfWork unitOfWork,
        ILogger<BaseService<User, RegisterRequest, UpdateUserRequest, UserDto>> logger,
        IMapper mapper) : base(unitOfWork, logger, mapper)
    {
        
    }

    // public UserService(
    //     IUnitOfWork unitOfWork,
    //     ILogger<BaseService<User, RegisterRequest, UpdateUserRequest, UserDto>> logger) 
    //     : base(unitOfWork, logger)
    // {
    // }

    // private readonly IUnitOfWork _unitOfWork;
    // private readonly IPasswordHasher _passwordHasher;
    // private readonly ILogger<UserService> _logger;

    // public UserService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, ILogger<UserService> logger)
    // {
    //     _unitOfWork = unitOfWork;
    //     _passwordHasher = passwordHasher;
    //     _logger = logger;
    // }
    // public UserServices(
    //     IUnitOfWork _unitOfWork,
    //     ILogger<BaseService<User,RegisterRequest,UpdateUserRequest,UserDto>> _logger)
    //     :base(_unitOfWork,_logger)
    // {

    // }


    public Task<User> GetByUsernameAsync(string userName)
    {
        throw new NotImplementedException();
    }
    // public async Task<bool> CreateAsync(RegisterRequest request)
    // {
    //     try
    //     {
    //         var hashedPassword = _passwordHasher.HashPassword(request.Password);

    //         var user = User.Create(
    //             FullName.Create(request.FirstName, request.LastName),
    //             Email.Create(request.Email),
    //             request.UserName,
    //             Password.Create(hashedPassword)
    //          );

    //         await _unitOfWork.Users.AddAsync(user);
    //         await _unitOfWork.SaveChangesAsync();
    //         _logger.LogInformation($"User created with UserName: {request.UserName}");
    //         return true;
    //     }
    //     catch (System.Exception)
    //     {
    //         _logger.LogError($"could not create User with UserName: {request.UserName}");
    //         return false;     
    //     }

    // }
    //  public async Task<bool> UpdateAsync(UpdateUserRequest request)
    // {
    //     try
    //     {
    //         var user = await _unitOfWork.Users.GetByIdAsync(request.Id);
    //         if (user == null)
    //             throw new NotFoundException("کاربر یافت نشد.");

    //         user.UpdateFullName(FullName.Create(request.FirstName, request.LastName));
    //         user.UpdateRoles(request.Roles); // فرض بر اینه که متدی برای این کار در کلاس User وجود داره

    //         _unitOfWork.Users.Update(user);
    //         await _unitOfWork.SaveChangesAsync();
    //         _logger.LogInformation($"User created with FirstName: {request.FirstName} LastName: {request.LastName}");
    //         return true;
    //      }
    //     catch (System.Exception)
    //     {
    //         _logger.LogError($"could not update User with FirstName: {request.FirstName} LastName: {request.LastName}");
    //         return false;
    //     }
    // }

    // public async Task<bool> DeleteAsync(Guid id)
    // {
    //     FullName? fullName = null;
    //     try
    //     {
    //         var user = await _unitOfWork.Users.GetByIdAsync(id);
    //         if (user == null) return false;
    //         fullName = user.FullName;
    //         _unitOfWork.Users.Remove(user);
    //         await _unitOfWork.SaveChangesAsync();
    //         _logger.LogInformation($"User created {fullName.ToString()}");
    //         return true;
    //     }
    //     catch (System.Exception)
    //     {
    //         _logger.LogInformation($"Could not Delete User  {(fullName!=null?fullName.ToString():"")}");
    //         return false;

    //     }
    // }

    // public async Task<IEnumerable<UserDto>> GetAllAsync()
    // {
    //      var users = await _unitOfWork.Users.GetAllAsync();
    //      return users.Select(u => new UserDto
    //      {
    //          Id = u.Id,
    //          FullName = u.FullName.ToString(),
    //          Email = u.Email.ToString(),
    //          Roles = u.Roles.Select(r => r.Name).ToList()
    //      });
    // }

    // public Task<UserDto?> GetByIdAsync(Guid id)
    // {
    //     throw new NotImplementedException();
    // }

    // public Task<User> GetByUsernameAsync(string userName)
    // {
    //     throw new NotImplementedException();
    // }





    // public async Task<IEnumerable<UserDto>> GetAllAsync()
    // {
    //     var users = await _unitOfWork.Users.GetAllAsync();
    //     return users.Select(u => new UserDto
    //     {
    //         Id = u.Id,
    //         FullName = u.FullName.ToString(),
    //         Email = u.Email.ToString(),
    //         Roles = u.Roles.Select(r => r.Name).ToList()
    //     });
    // }

    // // public async Task<UserDto?> GetByIdAsync(Guid id)
    // // {
    // //     var user = await _unitOfWork.Users.GetByIdAsync(id);
    // //     if (user == null) return null;

    // //     return new UserDto
    // //     {
    // //         Id = user.Id,
    // //         FullName = user.FullName.ToString(),
    // //         Email = user.Email.ToString(),
    // //         Roles = user.Roles.Select(r => r.Name).ToList()
    // //     };
    // // }

    // public async Task CreateAsync(RegisterRequest request)
    // {
    //     var hashedPassword=_passwordHasher.HashPassword(request.Password);

    //     var user = User.Create(
    //         FullName.Create(request.FirstName, request.LastName),
    //         Email.Create(request.Email),
    //         request.UserName,
    //         Password.Create(hashedPassword)
    //         );

    //     await _unitOfWork.Users.AddAsync(user);
    //     await _unitOfWork.SaveChangesAsync();
    // }

    // public async Task UpdateAsync(Guid id, UpdateUserRequest request)
    // {
    //     var user = await _unitOfWork.Users.GetByIdAsync(id);
    //     if (user == null)
    //         throw new NotFoundException("کاربر یافت نشد.");

    //     user.UpdateFullName(FullName.Create(request.FirstName, request.LastName));
    //     user.UpdateRoles(request.Roles); // فرض بر اینه که متدی برای این کار در کلاس User وجود داره

    //     _unitOfWork.Users.Update(user);
    //     await _unitOfWork.SaveChangesAsync();
    // }

    // public async Task DeleteAsync(Guid id)
    // {
    //     var user = await _unitOfWork.Users.GetByIdAsync(id);
    //     if (user == null) return;

    //     _unitOfWork.Users.Remove(user);
    //     await _unitOfWork.SaveChangesAsync();
    // }

    // public Task<User> GetByUsernameAsync(string userName)
    // {
    //     throw new NotImplementedException();
    // }

    // public async Task<IEnumerable<User>> IService<User>.GetAllAsync()
    // {
    //     var users = await _unitOfWork.Users.GetAllAsync();
    //     return users.Select(u => new UserDto
    //     {
    //         Id = u.Id,
    //         FullName = u.FullName.ToString(),
    //         Email = u.Email.ToString(),
    //         Roles = u.Roles.Select(r => r.Name).ToList()
    //     });
    // }

    // Task<User?> IService<User>.GetByIdAsync(Guid id)
    // {
    //     throw new NotImplementedException();
    // }

    // public Task<User> CreateAsync(User entity)
    // {
    //     throw new NotImplementedException();
    // }

    // public Task<RegisterRequest?> GetByIdAsync(Guid id)
    // {
    //     throw new NotImplementedException();
    // }

    // Task<IEnumerable<RegisterRequest>> IService<User, RegisterRequest>.GetAllAsync()
    // {
    //     throw new NotImplementedException();
    // }

    // Task<bool> IService<User, RegisterRequest>.CreateAsync(RegisterRequest dto)
    // {
    //     throw new NotImplementedException();
    // }

    // public Task<bool> UpdateAsync(RegisterRequest dto)
    // {
    //     throw new NotImplementedException();
    // }

    // Task<bool> IService<User, RegisterRequest>.DeleteAsync(Guid id)
    // {
    //     throw new NotImplementedException();
    // }
}
