using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RemburshmentAPI.DataBase
{
    public class DashBoard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime Date { get; set; }
        public int RequestedValue { get; set; }
        public int RemburshmentID { get; set; }

        [NotMapped]
        public string RemburshmentType { get; set; }

        public int CurrencyID { get; set; }
        [NotMapped]
        public string CurrencyType { get; set; }

        public string Image { get; set; }
        
        public string Status { get; set; }

        public string ApprovedBy { get; set; }
        public string Email { get; set; }
        public string ApprovedValue { get; set; }
        public string Note { get; set; }

        public DashBoard()
        {
            Status = "To be Processed";
        }
    }
}
