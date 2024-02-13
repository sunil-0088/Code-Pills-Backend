using Code_Pills.DataAccess.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Context
{
    public class CodePillsContext: DbContext
    {
        public CodePillsContext(DbContextOptions<CodePillsContext> options) : base(options) { }
        public DbSet<PersonalInfo> PersonalInformation { get; set; }
    }
}
