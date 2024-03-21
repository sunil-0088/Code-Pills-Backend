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
    public class FeatureUserConfig : IEntityTypeConfiguration<FeatureUserMapping>
    {
        public void Configure(EntityTypeBuilder<FeatureUserMapping> builder)
        {
            builder.HasKey(m =>  m.Id);
            builder.Property(m => m.FeatureId).IsRequired();
            builder.Property(m => m.UserId).IsRequired();


            builder.HasOne(f => f.PersonalInfo)
                .WithMany(q => q.FeaturedUserMapping)
                .HasForeignKey(k => k.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Feature)
                .WithMany(q => q.FeaturedUserMapping)
                .HasForeignKey(k => k.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
