using TestIdentity.Application.DTOs;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Domain.ValueObjects;
using TestIdentity.Application.Exceptions;
using TestIdentity.Domain.Entities;
using System.Text;
using System.Security.Cryptography;

namespace TestIdentity.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;
    private readonly ITokenApplicationService _tokenService;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IUnitOfWork unitOfWork, ITokenApplicationService tokenService, IPasswordHasher passwordHasher, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
        _userService = userService;
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        //var email = Email.Create(request.Email);
        var user = await _unitOfWork.Users.GetByUsernameAsync(request.UserName);
        if (user == null)
            throw new NotFoundException("کاربر یافت نشد.");

        if (!_passwordHasher.VerifyPassword(user.PasswordHash, request.Password))
            throw new ValidationException("رمز عبور اشتباه است.");

        var accessToken = _tokenService.GenerateAccessToken(user.Id, user.Roles.Select(r => r.Name).ToList());
        var refreshToken = _tokenService.GenerateRefreshToken();

        user.SetRefreshToken(refreshToken);
        await _unitOfWork.SaveChangesAsync();

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(30)
        };
    }

    public async Task LogoutAsync(Guid userId)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null) return;

        user.ClearRefreshToken();
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<string> RefreshTokenAsync(string refreshToken)
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        var matchedUser = users.FirstOrDefault(u => u.RefreshToken == refreshToken);
        if (matchedUser == null)
            throw new ValidationException("توکن نامعتبر است.");

        var newAccessToken = _tokenService.GenerateAccessToken(matchedUser.Id, matchedUser.Roles.Select(r => r.Name).ToList());
        return newAccessToken;
    }
    public async Task<bool> RegisterAsync(RegisterRequest registerDto)
    {
        // بررسی تکراری نبودن نام کاربری یا ایمیل
        var existingUser = await _unitOfWork.Users.GetByUsernameAsync(registerDto.UserName);
        if (existingUser != null)
            return false;

        var isEmailTaken = await _unitOfWork.Users.IsEmailTakenAsync(registerDto.Email);
        if (isEmailTaken)
            return false;
       
        // ساخت کاربر جدید
        //var user = User.Create(FullName.Create(registerDto.FirstName, registerDto.LastName),Email.Create(registerDto.Email),registerDto.UserName,Password.Create(hashedPassword));
        _userService.CreateAsync(registerDto);
        //user.UpdateRoles(registerDto.Roles);
        return true;
    }    

}
