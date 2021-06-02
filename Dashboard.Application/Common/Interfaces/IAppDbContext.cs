using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<State> States { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
