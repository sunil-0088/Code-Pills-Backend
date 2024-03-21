using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class FeatureQuestionMapping
    {
        public Guid Id { get; set; }
        public string QuestionId { get; set; }
        public Guid FeatureId { get; set; }
        public virtual Question Question { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
