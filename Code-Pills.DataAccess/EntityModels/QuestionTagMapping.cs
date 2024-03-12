
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class QuestionTagMapping
    {
        public Guid Id { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set;}
        public string QuestionId { get; set; }
        public virtual Question Question { get; set;}

        public static implicit operator List<object>(QuestionTagMapping? v)
        {
            throw new NotImplementedException();
        }
    }
}
