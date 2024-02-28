
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class PerformanceMapping
    {
        [Key]
        public Guid Id { get; set; }
        public required string TotalCredits { get; set; }
        public required string CreditsLeft { get; set; }
        public required string Rating { get; set; }
        public required string Attempts { get; set; }
        public required string Solved { get; set; }
        [ForeignKey("PersonalInfo")]
        public string PersonalInfoId { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}
