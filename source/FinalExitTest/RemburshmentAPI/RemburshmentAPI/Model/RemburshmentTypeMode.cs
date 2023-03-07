using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RemburshmentAPI.Model
{
    public class RemburshmentTypeMode
    {
        [Key]
        public int RemburshmentID { get; set; }
        public string RemburshmentType { get; set; }
    }
}
