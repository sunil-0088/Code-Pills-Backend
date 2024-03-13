using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.DTOs
{
    public class FeatureDTO
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? PillCount { get; set; }
        public List<string>? Questions { get; set; }
    }
}
