
using Sieve.Attributes;

namespace Code_Pills.DataAccess.Models
{
    public class ProblemsRes
    {
        public int TotalProblems { get; set; }
        public List<QuestionRes>? QuestionRes { get; set; }
    }
    public class QuestionRes
    {

        public required string Id { get; set; }

        [Sieve(CanSort = true, CanFilter = true)]
        public required string Title { get; set; }

        [Sieve(CanSort = true, CanFilter = true)]
        public string? Status { get; set; }

        [Sieve(CanSort = true, CanFilter = true)]
        public required string Difficulty { get; set; }
    }
}


