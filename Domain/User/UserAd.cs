using Domain.User.Entities;
using Domain.User.ValueObjects;
using SeedWork.Domain.Common;
using SeedWork.Domain.ExceptionValidation;

namespace Domain.User;

public sealed class UserAd : AgregateRoot<Guid>
{
    public UserName Name { get; private set; }
    public UserEmail Email { get; private set; }
    public string Password { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public List<Expense> _expenses = [];
    public IReadOnlyCollection<Expense> Expenses => _expenses.AsReadOnly();
 
#nullable disable
    private UserAd() { }
#nullable enable

    public UserAd(string name, string email, string password, DateTime creationDate)
    {
        Check.IsNotNull<ArgumentNullException>(name, "Name is required.");
        Check.IsNotNull<ArgumentOutOfRangeException>(email, "Email is required.");
        Check.IsNotNull<ArgumentNullException>(password, "Password is required.");

        Id = Guid.NewGuid();
        Name = new UserName(name);
        Email = new UserEmail(email);
        Password = password;
        CreatedDate = creationDate;
        UpdatedDate = creationDate;
    }

    public void Update(DateTime updateDate, string name, string email)
    {
        Check.IsNotNull<ArgumentNullException>(name, "Name is required.");
        Check.IsNotNull<ArgumentOutOfRangeException>(email, "Email is required.");

        Name = new UserName(name);
        Email = new UserEmail(email);
        UpdatedDate = updateDate;
    }

    public void UnRegister(DateTime updateDate)
    {
        UpdatedDate = updateDate;
    }

    public void AddExpense(Expense expense)
    {
        _expenses.Add(expense);
    }
}
