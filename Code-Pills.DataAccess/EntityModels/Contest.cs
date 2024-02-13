using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class Contest
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string Prize1 { get; set; }
        public string Prize2 { get; set; }
        public string Prize3 { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Attendees { get; set; }
        public string Winner1 { get; set; }
        public string Winner2 { get; set;}
        public string Winner3 { get; set;}
    }
}
