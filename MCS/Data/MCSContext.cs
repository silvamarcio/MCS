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
        public DbSet<MCS.Models.BalanceSheet> BalanceSheet { get;set;}
        public DbSet<MCS.Models.Employee> Employees { get;set;}
    }
}
