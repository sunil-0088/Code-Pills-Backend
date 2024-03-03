
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
        public Guid Id { get; set; }
        public int TotalCredits { get; set; }
        public int CreditsLeft { get; set; }
        public float Rating { get; set; }
        public int Attempts { get; set; }
        public int Solved { get; set; }
        public string UserId { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}
