using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.Data.Mappers;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users_Domain { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
