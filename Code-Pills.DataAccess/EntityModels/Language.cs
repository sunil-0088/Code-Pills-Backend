
using System.ComponentModel.DataAnnotations;

namespace Code_Pills.DataAccess.EntityModels
{
    public class Language
    {

        [Key]
        public required string Name { get; set; }
        public required int LanguageId { get; set; }
        public required string Value { get; set; }
    }
}
