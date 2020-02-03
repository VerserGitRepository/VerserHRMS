using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace VerserHRManagement.Models
{

    public class FileModel
    {
        public int Id { get; set; }

        public string FileUpload { get; set; }


        public string FileName { get; set; }

        public FileInfo File { get; set; }
      

       
    }
}
