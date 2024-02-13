
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class QuestioTagMapping
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int TagId { get; set; }
    }
}
