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
    public class ContestQuestionConfig : IEntityTypeConfiguration<ContestQuestionMapping>
    {
        public void Configure(EntityTypeBuilder<ContestQuestionMapping> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.QuestionId).IsRequired();
            builder.Property(c => c.ContestId).IsRequired();  

            builder.HasOne(c => c.Question)
                .WithMany(q => q.ContestQuestionMapping)
                .HasForeignKey(k => k.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Contest)
                .WithMany(q => q.ContestQuestionMapping)
                .HasForeignKey(k => k.ContestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
