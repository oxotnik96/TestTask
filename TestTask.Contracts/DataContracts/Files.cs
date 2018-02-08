using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Contracts.DataContracts
{
    public class Files
    {
        [Key]
        public int ID_of_file { get; set; }
        public string Way { get; set; }
        public string Title { get; set; }
        public int Size { get; set; }
        public ICollection<MainLog> Mainlog { get; set; }
    }
}
