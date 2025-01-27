using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities.FiscalYears;

namespace Project.Infrastructure.Contexts
{
    public class DataBaseContext : DbContext
    {

        #region ctor

        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        #endregion

        #region Properties

        public DbSet<FiscalYear> FiscalYears { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureFluentApi(modelBuilder);
           
            ApplyQueryFilter(modelBuilder);

            SeedData(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Deleted);
           
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Modified)
                {
                    if (entry.GetType().GetProperty("UpdateTime") == null || entry.GetType().GetProperty("UpdateTime") != null)
                    {
                        entry.Property("UpdateTime").CurrentValue = DateTime.Now;
                    }
                }

                if (entry.State == EntityState.Deleted)
                {
                    if (entry.GetType().GetProperty("Removed") == null)
                    {
                        entry.Property("RemoveTime").CurrentValue = DateTime.Now;
                        entry.Property("IsRemoved").CurrentValue = true;
                        entry.State = EntityState.Modified;
                    }
                }
            }
            
            
            return await base.SaveChangesAsync(cancellationToken);
        }


        private void ConfigureFluentApi(ModelBuilder modelBuilder)
        {

        }

        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FiscalYear>().HasQueryFilter(p => !p.IsRemoved);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {

        }

        #endregion

    }
}
