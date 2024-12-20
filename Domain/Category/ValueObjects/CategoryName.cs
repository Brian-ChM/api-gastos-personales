using SeedWork.Domain.Common;

namespace Domain.Category.ValueObjects;

public class CategoryName : ValueObject
{
    public string Value { get; } = string.Empty;

    private CategoryName() { }

    public CategoryName(string name)
    {
        if(string.IsNullOrWhiteSpace(name)) 
            throw new ArgumentNullException("Name", "Name is required.");

        if (name.Length >= 20)
            throw new ArgumentException("Name", "Name is too long.");

        Value = name;
    }

    protected override IEnumerable<object> GetEqualityComponents() => [Value];
}
