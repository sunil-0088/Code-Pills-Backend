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
    public class QuestionTagConfig : IEntityTypeConfiguration<QuestionTagMapping>
    {
        public void Configure(EntityTypeBuilder<QuestionTagMapping> builder)
        {
            builder.HasKey(qt => qt.Id);
            builder.Property(qt => qt.QuestionId).IsRequired();
            builder.Property(qt => qt.TagId).IsRequired();

            builder.HasOne(qt => qt.Tag)
                .WithMany(qt => qt.QuestionTagMapping)
                .HasForeignKey(qt => qt.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(qt => qt.Question)
                .WithMany(qt => qt.QuestionTagMapping)
                .HasForeignKey(qt => qt.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
