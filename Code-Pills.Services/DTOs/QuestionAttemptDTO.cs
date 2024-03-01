using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.DTOs
{
    public class QuestionAttemptDTO
    {
        public string UserId { get; set; }
        public string QuestionId { get; set; }
        public bool IsSolved { get; set; }
        public string Solution { get; set; }
    }
}
