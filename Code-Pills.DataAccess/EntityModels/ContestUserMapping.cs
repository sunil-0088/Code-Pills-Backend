using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class ContestUserMapping
    {
        [Key] 
        public int Id { get; set; }
        public required string Status { get; set; }
        public string? TimeTaken { get; set; }
        public virtual Contest Contest { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }

    }
}
