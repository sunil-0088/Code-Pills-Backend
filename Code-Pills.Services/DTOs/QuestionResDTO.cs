
namespace Code_Pills.Services.DTOs
{
     public class ProblemsResDTO
    {
        public int TotalProblems { get; set; }
        public List<QuestionResDTO>? QuestionRes { get; set; }
    }
    public class QuestionResDTO
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Status { get; set; }
        public required string Difficulty { get; set; }

    }
}
