
using System.ComponentModel.DataAnnotations;

namespace Code_Pills.DataAccess.EntityModels
{
    public class Language
    {

        [Key]
        [Required]
        public required int LanguageId { get; set; }
        public required string Value { get; set; }
        public required string Name { get; set; }
    }
}
