using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<Sport> Sports { get; set; }
        DbSet<State> States { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<Type> Types { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
