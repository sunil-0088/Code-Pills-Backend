using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Credits { get; set; }
        public required string Difficulty { get; set; }
        public int Submissions { get; set; }
        public int Likes { get; set; }
        public int Shares { get; set; }
        public int Attempts { get; set; }
        public virtual ICollection<UserQuestionMapping> UserQuestionMapping { get; set; }
        public virtual ICollection<QuestionTagMapping> QuestionTagMapping { get; set; }
    }
}
