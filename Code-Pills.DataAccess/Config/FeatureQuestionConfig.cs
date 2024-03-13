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
    public class FeatureQuestionConfig : IEntityTypeConfiguration<FeatureQuestionMapping>
    {
        public void Configure(EntityTypeBuilder<FeatureQuestionMapping> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.QuestionId).IsRequired();
            builder.Property(f => f.FeatureId).IsRequired();

            builder.HasOne(f => f.Feature)
                .WithMany(q => q.FeaturedQuestionMapping)
                .HasForeignKey(k => k.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Question)
                .WithMany(q => q.FeaturedQuestionMapping)
                .HasForeignKey(k => k.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
