using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context (DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
        }

        public DbSet< Departments> Departments { get; set; }
        public DbSet< SallesRecord> SallesRecord { get; set; }
        public DbSet< Seller> Seller { get; set; }
          }
}
