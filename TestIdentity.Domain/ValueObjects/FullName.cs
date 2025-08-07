namespace TestIdentity.Domain.ValueObjects;

public sealed class FullName
{
    public string FirstName { get; }
    public string LastName { get; }

    private FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static FullName Create(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("نام و نام خانوادگی نمی‌توانند خالی باشند.");

        return new FullName(firstName.Trim(), lastName.Trim());
    }

    public override bool Equals(object? obj) =>
        obj is FullName other &&
        FirstName == other.FirstName &&
        LastName == other.LastName;

    public override int GetHashCode() =>
        HashCode.Combine(FirstName, LastName);

    public override string ToString() => $"{FirstName} {LastName}";
}
