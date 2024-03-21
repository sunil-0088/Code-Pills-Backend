using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Models
{
    public class GlobalRank
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string? RankBadge { get; set; }
        public int Credits { get; set; }
        public float Rating { get; set; }
        public int Accuracy { get; set; }
    }
}
