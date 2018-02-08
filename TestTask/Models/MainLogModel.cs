using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class MainLogModel
    {
        [Key]
        public int ID { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }
        public int result { get; set; }
    }
}