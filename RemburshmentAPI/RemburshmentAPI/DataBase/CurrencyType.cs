using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RemburshmentAPI.DataBase
{
    public class Currencytype
    {
        [Key]
        public int CurrencyID { get; set; }

        public string CurrencyType { get; set; }
    }
}
