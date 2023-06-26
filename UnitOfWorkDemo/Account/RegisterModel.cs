using System;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkDemo.Account
{
    public class RegisterModel 
    {
        
            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }  
        
            [Required]
            //[EmailAddress]
            public string Email { get; set; }
    

            public string PhoneNumber { get; set; }

            [Required]
            //[DataType(DataType.Password)]
           // [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {0} characters long.", MinimumLength =6)]
            public string Password { get; set; }

        /*
            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Password do not match")]
            public string ConfirmPassword { get; set;}
        *
        }

       

    }
