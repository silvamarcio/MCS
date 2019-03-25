using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MCS.Models
{
    public class MCSContext : DbContext
    {
        public MCSContext (DbContextOptions<MCSContext> options)
            : base(options)
        {
        }

        public DbSet<MCS.Models.Occupation> Occupation { get; set; }
    }
}
