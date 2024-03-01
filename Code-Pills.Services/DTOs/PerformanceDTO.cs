using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.DTOs
{
    public class PerformanceDTO
    {
        public string UserID { get; set; }
        public int TotalCredits { get; set; }
        public int CreditsLeft { get; set; }
        public float Rating { get; set; }
        public int Attempts { get; set; }
        public int Solved { get; set; }  


    }
}
