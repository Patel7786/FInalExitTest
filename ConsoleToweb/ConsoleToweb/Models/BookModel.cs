using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ConsoleToweb.Models
{

    public class BookModel
    {
        [DataType(DataType.DateTime)]
        [Display(Name ="Date and Time")]
        public string MyFeild { get; set; }
        public int Id { get; set; }

        [StringLength(100,MinimumLength =5)]
        [Required(ErrorMessage ="Please Enter the Titel")]

        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        public string Category { get; set; }
        public string Laungage { get; set; }

       
        [Required]
        [Display(Name = "Total Pages")]
        public int ? TotalPages { get; set; }
        
    }
}
