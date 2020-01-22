using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestLap.Data
{
    public class ApplicationUser : IdentityUser
    {
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public String FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }

    }
}
