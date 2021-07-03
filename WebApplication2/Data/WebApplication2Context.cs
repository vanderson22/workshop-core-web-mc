using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    /// <summary>
    /// Contains dbSet's from application
    /// </summary>
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context(DbContextOptions<WebApplication2Context> options)
            : base(options) {
        }

        public DbSet<Departments> Departments { get; set; }
        public DbSet<SalesRecord> SallesRecord { get; set; }
        public DbSet<Seller> Seller { get; set; }
       
    }
}
