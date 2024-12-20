using Domain.Category.ValueObjects;
using Domain.User.Entities;
using SeedWork.Domain.Common;
using SeedWork.Domain.ExceptionValidation;

namespace Domain.Category;

public sealed class CategoryAd : AgregateRoot<Guid>
{
    public CategoryName Name { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Guid UserId { get; private set; }

    public List<Expense> _expenses = [];
    public IReadOnlyCollection<Expense> Expenses => _expenses;

#nullable disable
    private CategoryAd() { }
#nullable enable

    public CategoryAd(string name, DateTime creationDate, Guid userId)
    {
        Check.IsNotNull<ArgumentNullException>(name, "Name is required.");
        Check.IsNotNull<ArgumentNullException>(creationDate, "CreationDate is required.");
        Check.IsNotNull<ArgumentNullException>(UserId, "UserId is required.");

        Name = new CategoryName(name);
        CreatedAt = creationDate;
        UpdatedAt = creationDate;
        UserId = userId;
    }

    public void Update(DateTime updateDate, string name)
    {
        Check.IsNotNull<ArgumentNullException>(name, "Name is required.");
        Check.IsNotNull<ArgumentNullException>(updateDate, "UpdateDate is required.");
    
        Name = new CategoryName(name);
        UpdatedAt = updateDate;
    }

    public void UnRegister(DateTime updateDate)
    {
        UpdatedAt = updateDate;
    }

    public void AddExpense(Expense expense)
    {
        _expenses.Add(expense);
    }
}
