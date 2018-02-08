using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class FilesModel
    {
        [Key]
        public int ID_of_file { get; set; }
        public string Way { get; set; }
        public string Title { get; set; }
        public int Size { get; set; }
    }
}