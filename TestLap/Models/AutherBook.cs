using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestLap.Models
{
    public class AutherBook
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        [Display(Name = "Auther Name")]
        public int AutherId { get; set; }
        [ForeignKey("AutherId")]
        public Auther Auther { get; set; }

        [Required(ErrorMessage = "This Filed is Required")]
        [Display(Name = "Book Name")]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreateAt { get; set; }
        [ScaffoldColumn(false)]
        public String CreateBy { get; set; }

    }
}
