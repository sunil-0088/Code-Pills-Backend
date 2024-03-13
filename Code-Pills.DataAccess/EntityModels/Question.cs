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
        public string Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public string Difficulty { get; set; }
        public int Submissions { get; set; }
        public int Likes { get; set; }
        public int Shares { get; set; }
        public int Attempts { get; set; }
        public virtual ICollection<UserQuestionMapping> UserQuestionMapping { get; set; }
        public virtual ICollection<QuestionTagMapping> QuestionTagMapping { get; set; }
        public virtual ICollection<ContestQuestionMapping> ContestQuestionMapping { get; set; }
        public virtual ICollection<FeatureQuestionMapping> FeaturedQuestionMapping { get; set; }
    }
}
