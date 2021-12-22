using Microsoft.EntityFrameworkCore;
using TestAsp.Data.Entities;

namespace TestAsp.Data
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions opts) : base(opts)
        {

        }

        public DbSet<AppProduct> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Product Configuration
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            #endregion
        }
    }
}
