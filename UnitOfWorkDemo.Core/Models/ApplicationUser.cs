using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkDemo.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }



    }
}
