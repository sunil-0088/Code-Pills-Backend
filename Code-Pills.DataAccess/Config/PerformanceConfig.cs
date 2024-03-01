using Code_Pills.DataAccess.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Config
{
    public class PerformanceConfig : IEntityTypeConfiguration<PerformanceMapping>
    {
        public void Configure(EntityTypeBuilder<PerformanceMapping> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TotalCredits).IsRequired();
            builder.Property(p => p.CreditsLeft).IsRequired();
            builder.Property(p => p.Attempts).IsRequired();
            builder.Property(p => p.Solved).IsRequired();
            builder.Property(p => p.UserId).IsRequired();

            builder.HasOne(p => p.PersonalInfo)
                .WithOne(p => p.PerformanceMapping)
                .HasForeignKey<PerformanceMapping>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
