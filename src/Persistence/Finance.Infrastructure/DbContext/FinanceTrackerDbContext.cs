using Domain.Entities;

namespace Infrastructure.DbContext;

using Microsoft.EntityFrameworkCore;

public class FinanceTrackerDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<AccountHolder> AccountHolders{ get; set; }

    public FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity => {
            entity.HasKey(c => c.Id); 
            
            entity.HasMany(c => c.Expenses) 
                .WithOne(e => e.Category) 
                .HasForeignKey(e => e.CategoryId) 
                .OnDelete(DeleteBehavior.Cascade); 
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id); 

            entity.HasOne(e => e.Category) 
                .WithMany(c => c.Expenses) 
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); 
        });
    }
    
    public void EnsureDatabaseCreated()
    {
        Database.EnsureCreated(); 
    }
}