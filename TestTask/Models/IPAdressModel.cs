using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class IPAdressModel
    {
        [Key]
        public int ID_IP { get; set; }
        public string IP { get; set; }
        public string Name_of_company { get; set; }
    }
}