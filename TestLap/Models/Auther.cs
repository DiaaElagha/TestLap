using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestLap.Models
{
    public class Auther
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        [Display(Name = "Full Name")]
        public String Name { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? CreateAt { get; set; }
        [ScaffoldColumn(false)]
        public String CreateBy { get; set; }
    }
}
