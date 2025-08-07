using TestIdentity.Application.DTOs;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Domain.ValueObjects;
using TestIdentity.Application.Exceptions;

namespace TestIdentity.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly TestIdentity.Application.Interfaces.ITokenService _tokenService;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IUnitOfWork unitOfWork, TestIdentity.Application.Interfaces.ITokenService tokenService, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var email = Email.Create(request.Email);
        var user = await _unitOfWork.Users.GetByUsernameAsync(email.Value);
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
}
