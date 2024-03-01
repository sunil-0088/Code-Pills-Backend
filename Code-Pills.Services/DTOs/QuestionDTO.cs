using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.DTOs
{
    public class QuestionDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public string Difficulty { get; set; }
        public int Submissions { get; set; }
        public int Likes { get; set; }
        public int Shares { get; set; }
        public int Attempts { get; set; }
    }
}
