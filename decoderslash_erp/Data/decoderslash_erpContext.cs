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
        public int UserId { get; set; }
        public DbSet<decoderslash_erp.Models.Credentials> Credentials { get; set; } = default!;
        public DbSet<decoderslash_erp.Models.Employee> Employees { get; set; } = default!;
        public DbSet<decoderslash_erp.Models.Project> Projects { get; set; } = default!;
        public override int SaveChanges()
        {
            var addedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
            var updatedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
            var deletedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted).ToList();

            foreach(var entity in addedEntries)
            {
                var data = entity.Entity;
                var temp = (Audit0)data;
                temp.UserAdd = UserId;
                temp.isActive = true;
                temp.CreatedDate = DateTime.Now;
                temp.ModifiedDate = DateTime.Now;

            }

            foreach (var entity in updatedEntries)
            {
                var temp = (Audit0)entity.Entity;
                temp.UserMod = UserId;
                temp.ModifiedDate = DateTime.Now;
            }

            foreach(var entity in deletedEntries)
            {
                try
                {
                    var temp = (Audit0)entity.Entity;
                    temp.isActive = false;
                    temp.UserDel = UserId;
                    entity.State = EntityState.Modified;
                }
                catch
                {
                    continue;
                }   
                
            }
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
