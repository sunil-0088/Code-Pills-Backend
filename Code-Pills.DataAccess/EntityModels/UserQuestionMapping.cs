using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class UserQuestionMapping
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsSolved { get; set; }
        public string? Solution { get; set; }
        public virtual Question Question { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}
