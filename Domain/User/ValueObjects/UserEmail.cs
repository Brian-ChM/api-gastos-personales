using System.Xml.Linq;
using SeedWork.Domain.Common;

namespace Domain.User.ValueObjects;

public class UserEmail : ValueObject
{
    public string Value { get; } = string.Empty;

    public UserEmail() { }

    public UserEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException("Email", "Email is required.");

        if (email.Length > 60)
            throw new ArgumentOutOfRangeException("Email", "Email is to long.");

        Value = email;
    }

    protected override IEnumerable<object> GetEqualityComponents() => [Value];
}
