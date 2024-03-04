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
        public DbSet<UserOtp> UserOtp { get; set; }
    }
}
