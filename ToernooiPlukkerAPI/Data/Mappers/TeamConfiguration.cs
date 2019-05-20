using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Data.Mappers
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Team");
            builder.HasKey(t => t.TeamId);
            builder.HasOne(t => t.Toernooi).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(t => t.Spelers).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
