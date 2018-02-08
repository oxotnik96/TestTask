using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Contracts.DataContracts
{
    public class MainLog
    {
        [Key]
        public int ID { get; set; }
        public Files Files { get; set; }
        public IPAdress IpAdress { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }
        public int result { get; set; }
    }
}
