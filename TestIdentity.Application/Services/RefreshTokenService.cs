
using TestIdentity.Application.Interfaces;
using TestIdentity.Application.Common;
using TestIdentity.Application.DTOs;

namespace TestIdentity.Application.Services;
public class RefreshTokenService : IRefreshTokenService
{
    private readonly IRefreshTokenRepository _repository;
    private readonly ITokenGenerator _tokenGenerator;

    public RefreshTokenService(IRefreshTokenRepository repository, ITokenGenerator tokenGenerator)
    {
        _repository = repository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> GenerateTokenAsync(UserDto user)
    {
        var token = _tokenGenerator.Generate();
        var refreshToken = new RefreshToken
        {
            Token = token,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            IsRevoked = false
        };
        await _repository.AddAsync(refreshToken);
        return token;
    }

    public async Task<Result<string>> RefreshAsync(string oldToken)
    {
        var existing = await _repository.GetByTokenAsync(oldToken);
        if (existing == null || existing.IsRevoked || existing.ExpiresAt < DateTime.UtcNow)
            return Result<string>.Fail("Invalid or expired token");

        await _repository.RevokeAsync(oldToken);
        var newToken = await GenerateTokenAsync(new UserDto { Id = existing.UserId });
        return Result<object>.Ok(newToken);
    }
}
