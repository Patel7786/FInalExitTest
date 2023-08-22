using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookEvent.Models
{
    public class RegisterModel
    {
        [Required]
        public String FullName { get; set; }


        [Required]
        //[Remote("EmailExists", "Account", HttpMethod = "POST", ErrorMessage = "Email address already registered.")]
        [EmailAddress(ErrorMessage = "Please input Correct Email")]
        public string Email { get; set; }

        //[RegularExpression(".+\\.*+\\.@+.\\..+",ErrorMessage ="Please enter one special character")]
        [Required]
        [StringLength(100, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*[$@$!%#?&])(?=.*[A-Za-z]).{5,}", ErrorMessage = "Please enter one special character")]
        public String Password { get; set; }   

        [Key]
        public int ID { get; set; }


        
    }
}
