using Sieve.Attributes;

namespace Code_Pills.DataAccess.EntityModels
{
    public class Question
    {
        public string Id { get; set; }

        [Sieve(CanFilter = true)]
        public string Title { get; set; }
        [Sieve(CanSort = true, CanFilter = true)]
        public int Credits { get; set; }
        [Sieve(CanSort = true, CanFilter = true)]
        public string Difficulty { get; set; }
        [Sieve(CanSort = true)]
        public int Submissions { get; set; }
        [Sieve(CanSort = true)]
        public int Likes { get; set; }
        [Sieve(CanSort = true)]
        public int Shares { get; set; }
        [Sieve(CanSort = true)]
        public int Attempts { get; set; }
        public virtual ICollection<UserQuestionMapping> UserQuestionMapping { get; set; }
        public virtual ICollection<QuestionTagMapping> QuestionTagMapping { get; set; }
        public virtual ICollection<ContestQuestionMapping> ContestQuestionMapping { get; set; }
        public virtual ICollection<FeatureQuestionMapping> FeaturedQuestionMapping { get; set; }
    }
}
