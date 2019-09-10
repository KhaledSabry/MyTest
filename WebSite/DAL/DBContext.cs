using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.DAL.Models;

namespace WebSite.DAL
{
     
        public class DBContext : DbContext
        {
            public DBContext(DbContextOptions<DBContext> options)
               : base(options)
            { }

            public DbSet<item> items { get; set; }
            public DbSet<category> categories { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            { 
                modelBuilder.Entity<category>().HasData(
                    new category() { ID = 1, name = "Clothing" },
                   new category() { ID = 2, name = "Electronics" },
                   new category() { ID = 3, name = "Kitchen" },
                   new category() { ID = 4, name = "Misc" }
                   );

                base.OnModelCreating(modelBuilder);
            }
        }
     
}
