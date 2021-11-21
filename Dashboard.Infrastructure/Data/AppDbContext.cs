using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Common;
using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            ICurrentUserService currentUserService)
            :base(options)
        {
            _currentUserService = currentUserService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateSport>()
                .HasOne(s => s.State)
                .WithMany(ss => ss.StatesSports)
                .HasForeignKey(si => si.StateId);

            modelBuilder.Entity<StateSport>()
                .HasOne(s => s.Sport)
                .WithMany(ss => ss.StatesSports)
                .HasForeignKey(si => si.SportId);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<ArbitrageBet> ArbitrageBets { get; set; }
        public DbSet<ArbitrageMatch> ArbitrageMatches { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<PaymentAccount> PaymentAccounts { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StateSport> StatesSports { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Domain.Entities.Type> Types { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach(var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModifiedOn = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
