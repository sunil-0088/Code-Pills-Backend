
using Sieve.Models;

namespace Code_Pills.Services.DTOs
{
    public class QuestionSieveDTO : SieveModel
    {
        public List<int>? Tags { get; set; }
    }
}
