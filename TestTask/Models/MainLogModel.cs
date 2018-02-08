using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestTask.Contracts.DataContracts;

namespace TestTask.Models
{
    public class MainLogModel
    {
        [Key]
        public int ID { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }
        public int result { get; set; }

        public int IPAdressId { get; set; }
        public IEnumerable<IPAdress> IPAdress { get; set; }

        public int FilesId { get; set; }
        public IEnumerable<Files> Files { get; set; }
    }
}