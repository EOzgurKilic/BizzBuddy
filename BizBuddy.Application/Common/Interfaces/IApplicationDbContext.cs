using Microsoft.EntityFrameworkCore; // <- bu eksikti
using BizBuddy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace BizBuddy.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
