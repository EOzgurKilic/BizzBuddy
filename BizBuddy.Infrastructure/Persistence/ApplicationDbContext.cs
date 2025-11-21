using Microsoft.EntityFrameworkCore;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Account;
using BizBuddy.Domain.Entities.Categories;
using BizBuddy.Domain.Entities.Customers;
using BizBuddy.Domain.Entities.CustomFieldDefs;
using BizBuddy.Domain.Entities.InventoryMoves;
using BizBuddy.Domain.Entities.Orders;
using BizBuddy.Domain.Entities.Preset;
using BizBuddy.Domain.Entities.Products;
using BizBuddy.Domain.Entities.RoleAssignment;
using BizBuddy.Domain.Entities.Staff;
using BizBuddy.Domain.Entities.Tenats;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BizBuddy.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets
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
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Tenantt> Tenat { get; set; }

        // SaveChanges override
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        // Global Filters
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Branding>().OwnsOne(b => b.DarkMode);
            
            // 🔽 NEW: Appointment → Customer FK config
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Customer)          // navigation on Appointment
                .WithMany(c => c.Appointments)    // navigation collection on Customer
                .HasForeignKey(a => a.CustomerId) // FK property on Appointment
                .OnDelete(DeleteBehavior.Restrict);
            
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(ApplicationDbContext)
                        .GetMethod(nameof(SetSoftDeleteFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)?
                        .MakeGenericMethod(entityType.ClrType);

                    method?.Invoke(null, new object[] { modelBuilder });
                }
            }
        }

        private static void SetSoftDeleteFilter<TEntity>(ModelBuilder modelBuilder)
            where TEntity : BaseEntity
        {
            if (typeof(IActivatable).IsAssignableFrom(typeof(TEntity)))
            {
                modelBuilder.Entity<TEntity>().HasQueryFilter(e =>
                    !e.IsDeleted && ((IActivatable)e).IsActive);
            }
            else
            {
                modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
            }
        }
    }

    public interface IActivatable
    {
        bool IsActive { get; set; }
    }
}
