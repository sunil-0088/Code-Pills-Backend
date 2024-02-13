using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class QuestionMapping
    {
        [Key]
        public int Id { get; set; }
        public string UserID { get; set; }
        public string QuestionID { get; set; }
        public bool IsSolved { get; set; }
        public string Solution { get; set; }
    }
}
