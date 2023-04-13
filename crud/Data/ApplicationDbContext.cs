using crud.Models;
using Microsoft.EntityFrameworkCore;


namespace crud.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(c => c.Picture).HasColumnType("bytea");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
