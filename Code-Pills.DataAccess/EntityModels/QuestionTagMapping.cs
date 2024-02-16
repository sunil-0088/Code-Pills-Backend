
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class QuestionTagMapping
    {
        [Key]
        public int Id { get; set; }
        public virtual Tag Tag { get; set;}

        [ForeignKey("Question")]
        public string QuestionId { get; set; }
        public virtual Question Question { get; set;}
    }
}
