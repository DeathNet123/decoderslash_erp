using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using decoderslash_erp.Interfaces;

namespace decoderslash_erp.Data
{
    public class decoderslash_erpContext : DbContext
    {
        public decoderslash_erpContext (DbContextOptions<decoderslash_erpContext> options)
            : base(options)
        {
        }
        public int UserId { get; set; }
        public DbSet<decoderslash_erp.Models.Credentials> Credentials { get; set; } = default!;
        public DbSet<decoderslash_erp.Models.Employee> Employees { get; set; } = default!;
        public DbSet<decoderslash_erp.Models.Project> Projects { get; set; } = default!;
        public override int SaveChanges()
        {
            var addedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
            var updatedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
            var deletedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted).ToList();

            foreach(var entry in addedEntries)
            {
                var data = entry.Entity;
                var temp = (IAudit)data;
                temp.UserAdd = UserId;
                temp.isActive = true;
                temp.CreatedDate = DateTime.Now;
                temp.ModifiedDate = DateTime.Now;

            }

            foreach (var entry in updatedEntries)
            {
                var temp = (IAudit)entry.Entity;
                temp.UserMod = UserId;
                temp.ModifiedDate = DateTime.Now;
            }

            foreach(var entry in deletedEntries)
            {
                try
                {
                    var temp = (IAudit)entry.Entity;
                    temp.isActive = false;
                    temp.UserDel = UserId;
                    entry.State = EntityState.Modified;
                }
                catch
                {
                    continue;
                }   
                
            }
            ChangeTracker.DetectChanges();//just to remain safe
            return base.SaveChanges();
        }
    }
}
