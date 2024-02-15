using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class ContestQuestionMapping
    {
        [Key]
        public Guid Id { get; set; }
        public virtual Question Question { get; set; }
        public virtual Contest Contest { get; set; }
    }
}
