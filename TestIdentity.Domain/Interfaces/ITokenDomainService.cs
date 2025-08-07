using  TestIdentity.Domain.Entities;

namespace TestIdentity.Domain.Interfaces;

// public interface ITokenService
// {
//     string GenerateAccessToken(User user);
//     string GenerateRefreshToken();
//     bool ValidateToken(string token);

// }
public interface ITokenDomainService
    {
        /// <summary>
        /// تولید یک توکن دامنه‌ای برای کاربر
        /// </summary>
        Token GenerateToken(User user);

        /// <summary>
        /// اعتبارسنجی توکن
        /// </summary>
        bool IsTokenValid(Token token);

        /// <summary>
        /// بررسی انقضای توکن
        /// </summary>
        bool IsTokenExpired(Token token);
    }
