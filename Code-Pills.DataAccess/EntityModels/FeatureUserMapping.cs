using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class FeatureUserMapping
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid FeatureId { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
