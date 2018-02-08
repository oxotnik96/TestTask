using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Contracts.DataContracts
{
    public class IPAdress
    {
        [Key]
        public int ID_IP { get; set; }
        public string IP { get; set; }
        public string Name_of_company { get; set; }

        public ICollection<MainLog> Mainlog { get; set; }
    }
}
