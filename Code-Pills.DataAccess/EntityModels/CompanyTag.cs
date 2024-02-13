using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class CompanyTag
    {
        [Key]
        public int Id { get; set; }
        public string TagName { get; set; }
    }
}
