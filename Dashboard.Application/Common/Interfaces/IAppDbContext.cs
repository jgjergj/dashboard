﻿using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<ArbitrageBet> ArbitrageBets { get; set; }
        DbSet<ArbitrageMatch> ArbitrageMatches { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<League> Leagues { get; set; }
        DbSet<Operator> Operators { get; set; }
        DbSet<PaymentAccount> PaymentAccounts { get; set; }
        DbSet<Sport> Sports { get; set; }
        DbSet<State> States { get; set; }
        DbSet<StateSport> StatesSports { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<Type> Types { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
