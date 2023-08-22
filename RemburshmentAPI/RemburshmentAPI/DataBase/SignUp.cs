using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RemburshmentAPI.DataBase
{
    public class SignUp
    {
        public string FullName;//{ get; set; }
        public string PanNumber;// { get; set; }
        public string BankName;// { get; set; }
        public int AccountNumber;//{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int TypeID { get; set; }

        [NotMapped]
        public string Type { get; set;}
    }
}
