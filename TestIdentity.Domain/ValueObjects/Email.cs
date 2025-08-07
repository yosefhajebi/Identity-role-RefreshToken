using System.Text.RegularExpressions;

namespace TestIdentity.Domain.ValueObjects;

public sealed class Email
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("ایمیل نمی‌تواند خالی باشد.");

        var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(value, pattern))
            throw new ArgumentException("فرمت ایمیل معتبر نیست.");

        return new Email(value.Trim().ToLower());
    }

    public override bool Equals(object? obj) =>
        obj is Email other && Value == other.Value;

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value;
}
