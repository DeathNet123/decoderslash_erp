using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using decoderslash_erp.Models;

namespace decoderslash_erp.Data
{
    public class decoderslash_erpContext : DbContext
    {
        public decoderslash_erpContext (DbContextOptions<decoderslash_erpContext> options)
            : base(options)
        {
        }
        public DbSet<decoderslash_erp.Models.Credentials> Credentials { get; set; } = default!;
        public DbSet<decoderslash_erp.Models.Employee> Employees { get; set; } = default!;

        public override int SaveChanges()
        {
            var addedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
            var updatedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
            var deletedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted).ToList();
            return base.SaveChanges();
        }
    }
}
