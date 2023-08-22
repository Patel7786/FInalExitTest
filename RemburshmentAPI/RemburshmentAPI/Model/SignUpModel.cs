using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RemburshmentAPI.Model
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Please enter your Full Name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Please enter your PAN Number")]
        [Display(Name = "Pan Name")]
        [MinLength(10)]
        public string PanNumber { get; set; }

        [Required(ErrorMessage = "Please enter your bank Name")]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Please enter your Account Number")]
        [Display(Name = "Account Name")]
        [MinLength(10)]
        public int AccountNumber { get; set; }


        [Required(ErrorMessage = "Please enter your Email Address")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please provide a valid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [DataType(DataType.Password, ErrorMessage = "Please Provide a valid Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password, ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int TypeID { get; set; }
        [NotMapped]
        public string Type { get; set; }
    }
}
