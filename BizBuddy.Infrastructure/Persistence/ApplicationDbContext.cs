using Microsoft.EntityFrameworkCore;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Account;
using BizBuddy.Domain.Entities.Categorys;
using BizBuddy.Domain.Entities.Customers;
using BizBuddy.Domain.Entities.CustomFieldDefs;
using BizBuddy.Domain.Entities.InventoryMoves;
using BizBuddy.Domain.Entities.Orders;
using BizBuddy.Domain.Entities.Preset;
using BizBuddy.Domain.Entities.Tenats;
using BizBuddy.Domain.Entities.Products;
using BizBuddy.Domain.Entities.RoleAssignment;

namespace BizBuddy.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<CustomFieldDef> CustomFieldDef { get; set; }
    public DbSet<InventoryMove> InventoryMove { get; set; }
    public DbSet<Appointment> Appointment { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<PresetSettings> PresetSettings { get; set; }
    public DbSet<TenantSettings> TenantSettings { get; set; }
        public DbSet<Product> Product { get; set; }

    public DbSet<Branding> Branding { get; set; }

    public DbSet<Role> Role { get; set; }

    public DbSet<TenantSettings> TenantSettings { get; set; }

    public DbSet<TenantSettings> TenantSettings { get; set; }





    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = true;
                entry.Entity.DeletedAt = DateTime.UtcNow;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasQueryFilter(p => !p.IsDeleted);
        base.OnModelCreating(modelBuilder);
    }
}
