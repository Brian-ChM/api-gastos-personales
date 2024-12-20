using Domain.Category;
using Domain.User;
using Domain.User.Entities;
using Infraestructure.AppDbContext.EntityConfiguration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeedWork.Domain.Common;

namespace Infraestructure.AppDbContext;

public sealed class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options,
    IMediator mediator) : DbContext(options)
{
    private readonly IMediator _mediator = mediator;

    public DbSet<UserAd> Users { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<CategoryAd> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AddEntitiesConfiguration(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        int result = await base.SaveChangesAsync(cancellationToken);
        await DispatchDomainEventsForTrackedEntities().ConfigureAwait(false);
        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync(default).GetAwaiter().GetResult();
    }

    private static void AddEntitiesConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
    }

    private async Task DispatchDomainEventsForTrackedEntities()
    {
        if (_mediator == null)
            throw new NullReferenceException("Mediator is required.");

        var entitiesWithEvents = ChangeTracker.Entries<AgregateRoot<Guid>>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.DomainEvents.ToArray();
            entity.ClearEvents();
        }
    }
}
