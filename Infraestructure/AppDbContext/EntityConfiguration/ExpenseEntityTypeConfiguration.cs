using Domain.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.AppDbContext.EntityConfiguration;

public class ExpenseEntityTypeConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> entity)
    {
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id)
            .ValueGeneratedNever();

        entity.Property(x => x.Amount)
            .IsRequired();

        entity.Property(x => x.Date)
            .IsRequired();

        entity.Property(x => x.Description)
            .IsRequired();

        entity.Property(x => x.CategoryId)
            .IsRequired();

        entity.Property(x => x.UserId)
            .IsRequired();

        entity.HasOne(x => x.Category)
            .WithMany(x => x.Expenses)
            .HasForeignKey(x => x.CategoryId);
    }
}
