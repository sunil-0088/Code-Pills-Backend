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
        public Guid Id { get; set; }
        public bool IsSolved { get; set; }
        public string Solution { get; set; }
        public string UserId { get; set; }
        public string QuestionId { get; set; }
        public DateTime Date { get; set; }
        public virtual Question Question { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}
