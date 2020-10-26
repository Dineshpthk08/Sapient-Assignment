using Microsoft.EntityFrameworkCore;
using MedicineTracker.Models;

namespace MedicineTracker.Context
{
    public class MedicineDatabaseContext : DbContext
    {
        public MedicineDatabaseContext(
            DbContextOptions<MedicineDatabaseContext> dbContextOptions) 
            : base(dbContextOptions) { }

        public DbSet<Medicine> Medicines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>()
                .HasKey(x => x.Id);
        }
    }
}
