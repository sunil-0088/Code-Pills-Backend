using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class Feature
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PillCount { get; set; }
        public virtual ICollection<FeatureQuestionMapping> FeaturedQuestionMapping { get; set; }
        public virtual ICollection<FeatureUserMapping> FeaturedUserMapping { get; set; }
    }
}
