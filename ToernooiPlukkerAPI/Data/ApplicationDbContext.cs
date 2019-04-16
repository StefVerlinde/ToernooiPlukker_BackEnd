using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.Data.Mappers;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
