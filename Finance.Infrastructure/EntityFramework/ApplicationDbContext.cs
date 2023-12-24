using Finance.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infrastructure.EntityFramework
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AccountUser> AccountUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("connectionString", b => b.MigrationsAssembly("Finance.API"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Transaction>(eb =>
            {
                eb.Property(x => x.Name).IsRequired();
                eb.Property(x => x.Currency).IsRequired();
                eb.Property(x => x.Amount).IsRequired();
                eb.Property(x => x.UserId).IsRequired();
                eb.Property(x => x.CreatedDateTime).IsRequired();
                eb.Property(x => x.Description).IsRequired();
                eb.HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId);
                eb.HasIndex(t => t.Name)
                .IsUnique();

                eb.Property(x => x.Amount)
                .HasColumnType("decimal(18, 2)");

                eb.HasIndex(t => t.DeletedDateTime);
                eb.HasIndex(t => t.UserId);
            });

            modelBuilder.Entity<AccountUser>(b =>
            {
                b.Property(x => x.AccountBalance).IsRequired();
                b.Property(x => x.AccountBalance).HasColumnType("decimal(18, 2)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
