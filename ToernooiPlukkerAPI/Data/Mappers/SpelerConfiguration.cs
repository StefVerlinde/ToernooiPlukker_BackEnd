using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Data.Mappers
{
    public class SpelerConfiguration : IEntityTypeConfiguration<Speler>
    {
        public void Configure(EntityTypeBuilder<Speler> builder)
        {
            builder.ToTable("Speler");
            builder.HasKey(s => s.SpelerId);
            //builder.HasOne(s => s.Team).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
