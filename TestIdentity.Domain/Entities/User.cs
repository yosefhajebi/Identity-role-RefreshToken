using TestIdentity.Domain.ValueObjects;

namespace TestIdentity.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public FullName FullName { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }
    public List<Role> Roles { get; private set; } = new();

    public string? RefreshToken { get; private set; } // 👈 اضافه کن

    private User() { }

    public static User Create(FullName fullName, Email email, Password password)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            FullName = fullName,
            Email = email,
            PasswordHash = password.Value
        };
    }

    public void SetRefreshToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("توکن نمی‌تواند خالی باشد.");

        RefreshToken = token;
    }

    public void ClearRefreshToken()
    {
        RefreshToken = null;
    }

    public void UpdateFullName(FullName fullName)
    {
        FullName = fullName;
    }

    public void UpdateRoles(List<string> roleNames)
    {
        // فرض بر اینه که نقش‌ها از قبل در سیستم وجود دارن و باید به کاربر نسبت داده بشن
        Roles = roleNames.Select(name => Role.Create(name)).ToList();
    }
}
