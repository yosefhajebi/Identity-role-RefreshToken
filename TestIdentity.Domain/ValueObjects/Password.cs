namespace TestIdentity.Domain.ValueObjects;

public sealed class Password
{
    public string Value { get; }

    private Password(string value)
    {
        Value = value;
    }

    public static Password Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
            throw new ArgumentException("رمز عبور باید حداقل ۶ کاراکتر باشد.");

        return new Password(value);
    }

    public override bool Equals(object? obj) =>
        obj is Password other && Value == other.Value;

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => "********"; // امنیت!
}
