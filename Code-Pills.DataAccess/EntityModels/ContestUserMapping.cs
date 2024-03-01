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
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalPoints { get; set; }
        public string UserId { get; set; }
        public Guid ContestId { get; set; }
        public virtual Contest Contest { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }

    }
}
