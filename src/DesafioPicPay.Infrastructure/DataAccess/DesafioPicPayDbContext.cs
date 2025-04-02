using DesafioPicPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioPicPay.Infrastructure.DataAccess;

public class DesafioPicPayDbContext : DbContext
{
    public DesafioPicPayDbContext(DbContextOptions<DesafioPicPayDbContext> options) : base(options) { }

    #region DBSETS
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Transfer> Transfer { get; set; }
        public virtual DbSet<Account> Account { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioPicPayDbContext).Assembly);
    }
}
