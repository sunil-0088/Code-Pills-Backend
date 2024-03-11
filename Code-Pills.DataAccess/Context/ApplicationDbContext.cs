using Code_Pills.DataAccess.Config;
using Code_Pills.DataAccess.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<PersonalInfo> PersonalInformation { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ContestUserMapping> ContestUserMappings { get; set; }
        public DbSet<PerformanceMapping> PerformanceMappings { get; set; }
        public DbSet<ContestQuestionMapping> ContestQuestionMappings { get; set; }
        public DbSet<QuestionTagMapping> QuestionTagMappings { get; set; }
        public DbSet<UserQuestionMapping> UserQuestionMappings { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<UserOtp> UserOtp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ContestConfig());
            modelBuilder.ApplyConfiguration(new ContestQuestionConfig());
            modelBuilder.ApplyConfiguration(new ContestUserConfig());
            modelBuilder.ApplyConfiguration(new PerformanceConfig());
            modelBuilder.ApplyConfiguration(new PersonalInfoConfig());
            modelBuilder.ApplyConfiguration(new QuestionConfig());
            modelBuilder.ApplyConfiguration(new QuestionTagConfig());
            modelBuilder.ApplyConfiguration(new UserQuestionConfig());
        }
    }
}
