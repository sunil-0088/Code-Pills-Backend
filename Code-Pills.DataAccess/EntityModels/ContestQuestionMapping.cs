using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class ContestQuestionMapping
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Contest")]
        public Guid ContestId { get; set; }
        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual Contest Contest { get; set; }
    }
}
