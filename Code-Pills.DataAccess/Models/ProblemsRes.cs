
using Code_Pills.DataAccess.EntityModels;
using Sieve.Attributes;

namespace Code_Pills.DataAccess.Models
{
    public class ProblemsRes
    {
        public int TotalProblems { get; set; }
        public IQueryable<Question> QuestionsRes { get; set; }
    }
}


