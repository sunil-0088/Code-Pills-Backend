using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public required string TagName { get; set; }
        public required bool IsCompany { get; set; }
        public virtual ICollection<QuestionTagMapping> QuestionTagMapping { get; set; }
    }
}
