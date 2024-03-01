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
    public class UserQuestionConfig : IEntityTypeConfiguration<UserQuestionMapping>
    {
        public void Configure(EntityTypeBuilder<UserQuestionMapping> builder)
        {
            builder.HasKey(uq => uq.Id);
            builder.Property(uq => uq.IsSolved).IsRequired();
            builder.Property(uq => uq.Solution).IsRequired();
            builder.Property(uq => uq.UserId).IsRequired();
            builder.Property(uq => uq.QuestionId).IsRequired();

            builder.HasOne(uq => uq.Question)
                .WithMany(uq => uq.UserQuestionMapping)
                .HasForeignKey(uq => uq.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(uq => uq.PersonalInfo)
                .WithMany(uq => uq.UserQuestionMapping)
                .HasForeignKey(uq => uq.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
