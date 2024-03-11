using System.ComponentModel.DataAnnotations;


namespace Code_Pills.DataAccess.EntityModels
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public required string TagName { get; set; }
        public required bool IsCompany { get; set; }
        public virtual ICollection<QuestionTagMapping> QuestionTagMapping { get; set; }
    }
}
