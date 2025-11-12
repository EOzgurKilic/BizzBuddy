using Microsoft.EntityFrameworkCore; // <- bu eksikti
using BizBuddy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
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

namespace BizBuddy.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<CustomFieldDef> CustomFieldDef { get; set; }
        DbSet<InventoryMove> InventoryMove { get; set; }
        DbSet<Appointment> Appointment { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderItem> OrderItem { get; set; }
        DbSet<Payment> Payment { get; set; }
        DbSet<PresetSettings> PresetSettings { get; set; }
        DbSet<TenantSettings> TenantSettings { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Branding> Branding { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<Employee> Employee { get; set; }
        DbSet<Tenat> Tenat { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
