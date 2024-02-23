using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("PersonalInfo")]
        public string PersonalInfoId { get; set; }
        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}
