using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalCar7.Infrastructure7.Persistance;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RentalCar7.Infrastructure7.Persistance
{
    public partial class ApplicationDbContext : DbContext  //, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
		
		public virtual DbSet<AccountEnt> Account { get; set; }
		public virtual DbSet<CarsEnt> Cars { get; set; }
		public virtual DbSet<RentalCarsEnt> RentalCars { get; set; }

		
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=(local)\\MSSQLSERVER2017;Database=[yourDBName];Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public Task<int> SaveChangesAsync(bool cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}


