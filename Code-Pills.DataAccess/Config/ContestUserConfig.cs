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
    public class ContestUserConfig : IEntityTypeConfiguration<ContestUserMapping>
    {
        public void Configure(EntityTypeBuilder<ContestUserMapping> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.UserId).IsRequired();   
            builder.Property(c => c.ContestId).IsRequired();

            builder.HasOne(c => c.PersonalInfo)
                .WithMany(c => c.ContestUserMapping)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Contest)
                .WithMany(c => c.ContestUserMapping)
                .HasForeignKey(c => c.ContestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
