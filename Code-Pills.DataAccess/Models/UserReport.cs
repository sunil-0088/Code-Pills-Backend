using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Models
{
    public class UserReport
    {
        public List<int>? EasyCount { get; set; }
        public List<int>? MediumCount { get; set; }
        public List<int>? HardCount { get; set; }
        public Dictionary<int, int> DayCount { get; set; }

        public UserReport() { 
            this.DayCount = new Dictionary<int, int>();
        }
    }
}
