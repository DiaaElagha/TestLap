using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestLap.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        [Display(Name = "Full Name")]
        public String Name { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        [Display(Name = "Description")]
        public String Des { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? CreateAt{ get; set; }
        [ScaffoldColumn(false)]
        public String CreateBy{ get; set; }

    }
}
