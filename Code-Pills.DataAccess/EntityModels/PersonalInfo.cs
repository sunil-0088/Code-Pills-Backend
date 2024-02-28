using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class PersonalInfo
    {
        [Key]
        public required string Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? About { get; set; }
        public string? Profession { get; set; }
        public string? Gender { get; set; }
        public DateTime DOB { get; set;}
        public string? Skills { get; set; }
        public virtual ICollection<UserQuestionMapping> UserQuestionMapping { get; set; }
        public virtual PerformanceMapping PerformanceMapping { get; set; }
        public virtual ICollection<ContestUserMapping> ContestUserMapping { get; set; }
    }
}
