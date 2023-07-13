using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;

namespace myfinance_web_netcore
{
    public class MyFinanceDbContext : DbContext
    {
        public DbSet<PlanoConta> PlanoConta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=myFinance;User=sa;Password=@Wrkze795082;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}