using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class ContestUserMapping
    {
        [Key] 
        public Guid Id { get; set; }
        public string? Status { get; set; }
        public string? TimeTaken { get; set; }
        [ForeignKey("PersonalInfo")]
        public string PersonalInfoId { get; set; }
        [ForeignKey("Contest")]
        public Guid ContestId { get; set; }
        public virtual Contest Contest { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }

    }
}
