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
    public class ContestConfig : IEntityTypeConfiguration<Contest>
    {
        public void Configure(EntityTypeBuilder<Contest> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(e => e.Difficulty).IsRequired();
            builder.Property(c => c.StartTime).IsRequired();
            builder.Property(c => c.EndTime).IsRequired();
            builder.Property(c => c.IsWeekly).IsRequired();
            builder.Property(c => c.IsMonthly).IsRequired();
        }
    }
}
