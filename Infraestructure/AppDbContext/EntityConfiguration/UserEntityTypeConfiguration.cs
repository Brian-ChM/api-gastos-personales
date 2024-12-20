using Domain.Category.ValueObjects;
using Domain.User;
using Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.AppDbContext.EntityConfiguration;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserAd>
{
    public void Configure(EntityTypeBuilder<UserAd> entity)
    {
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id)
            .ValueGeneratedNever();

        entity.Property(m => m.Name)
             .HasConversion(prop => prop.Value, value => new UserName(value))
             .IsRequired();

        entity.Property(m => m.Email)
             .HasConversion(prop => prop.Value, value => new UserEmail(value))
             .IsRequired();

        entity.Property(x => x.Password)
            .IsRequired();

        entity.Property(x => x.CreatedDate)
            .IsRequired();

        entity.Property(x => x.UpdatedDate)
            .IsRequired();

        entity.HasMany(x => x.Expenses)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}
