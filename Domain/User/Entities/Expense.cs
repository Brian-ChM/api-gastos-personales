using Domain.Category;
using SeedWork.Domain.Common;
using SeedWork.Domain.ExceptionValidation;

namespace Domain.User.Entities;

public sealed class Expense : Entity<Guid>
{
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public Guid CategoryId { get; private set; }
    public CategoryAd Category { get; private set; }
    public Guid UserId { get; private set; }
    public UserAd User { get; private set; }

#nullable disable
    private Expense() { }

    public Expense(decimal amount, DateTime date, string description, Guid categoryId, Guid userId)
    {
        Check.IsNotNull<ArgumentNullException>(amount, "Amount is required");
        Check.That<ArgumentOutOfRangeException>(((amount <= 0)), "Amount must be greater than 0.");
        Check.IsNotNull<ArgumentNullException>(date, "Date is required");
        Check.IsNotNull<ArgumentNullException>(description, "Description is required");
        Check.That<ArgumentOutOfRangeException>(((description.Length <= 5)), "Description is too short.");

        Amount = amount;
        Date = date;
        Description = description;
        CategoryId = categoryId;
        UserId = userId;
    }
#nullable enable

    public void Update(decimal amount, DateTime date, string description)
    {
        Check.IsNotNull<ArgumentNullException>(amount, "Amount is required");
        Check.IsNotNull<ArgumentNullException>(date, "Date is required");
        Check.IsNotNull<ArgumentNullException>(description, "Description is required");
        Check.That<ArgumentException>(((description.Length <= 5)), "Description is too short.");

        Amount = amount;
        Date = date;
        Description = description;
    }

    public void UnRegister(DateTime dateTime)
    {
        Check.IsNotNull<ArgumentNullException>(dateTime, "Datetime is required");

        Date = dateTime;
    }
}
