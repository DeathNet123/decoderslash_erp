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

        public DbSet<decoderslash_erp.Models.Employees> Employees { get; set; } = default!;
    }
}
