using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.DTOs
{
    public class TagDTO
    {
        public required int Id { get; set; }
        public required string TagName { get; set; }
        public required string IsCompany { get; set; }
    }
}
