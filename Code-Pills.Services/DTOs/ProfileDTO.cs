using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.DTOs
{
    public class ProfileDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Skills { get; set; }
        public string Profesion { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
    }
}
