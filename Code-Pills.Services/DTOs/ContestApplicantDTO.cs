using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.DTOs
{
    public class ContestApplicantDTO
    {
        public Guid Id { get; set; }
        public Guid ContestId { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string TimeTaken { get; set; }
    }
}
