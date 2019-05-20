using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Data.Mappers
{
    public class ToernooiConfiguration : IEntityTypeConfiguration<Toernooi>
    {
        public void Configure(EntityTypeBuilder<Toernooi> builder)
        {
            builder.ToTable("Toernooi");
            builder.HasKey(t => t.ToernooiId);
            builder.HasOne(t => t.Creator).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(t => t.Teams).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
