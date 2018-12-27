using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartCodingNowWebManager.Areas.GIAOVIEN.Models
{
    public class Acount_model
    {
       
        public int IDTeacher { get; set; }

        public string oldpass { get; set; }
        public string newpass { get; set; }
        
    }
}