using Domain.Category;
using Domain.Category.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.AppDbContext.EntityConfiguration;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<CategoryAd>
{
    public void Configure(EntityTypeBuilder<CategoryAd> entity)
    {
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id)
            .ValueGeneratedNever();

        entity.Property(m => m.Name)
             .HasConversion(prop => prop.Value, value => new CategoryName(value))
             .IsRequired();

        entity.Property(x => x.CreatedAt)
            .IsRequired();

        entity.Property(x => x.UpdatedAt)
            .IsRequired();

        entity.Property(x => x.UserId)
            .IsRequired();

        entity.HasMany(x => x.Expenses)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}
