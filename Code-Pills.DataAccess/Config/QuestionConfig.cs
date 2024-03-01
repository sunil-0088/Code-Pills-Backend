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
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Title).IsRequired();
            builder.Property(q => q.Credits).IsRequired();
            builder.Property(q => q.Difficulty).IsRequired();
            builder.Property(q => q.Submissions).IsRequired();
            builder.Property(q => q.Likes).IsRequired();
            builder.Property(q => q.Attempts).IsRequired();
            builder.Property(q => q.Shares).IsRequired();
        }
    }
}
