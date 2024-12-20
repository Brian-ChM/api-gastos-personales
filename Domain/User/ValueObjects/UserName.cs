using SeedWork.Domain.Common;

namespace Domain.User.ValueObjects;

public class UserName : ValueObject
{
    public string Value { get; } = string.Empty;

    private UserName() { }
    public UserName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("Name", "Name is required.");

        if (name.Length > 60)
            throw new ArgumentOutOfRangeException("Name", "Name is to long.");

        Value = name;
    }

    protected override IEnumerable<object> GetEqualityComponents() => [Value];
}
