using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StartCodingNowWebManager.Areas.ADMIN.Models
{
    public class Teaching_Model
    {
        public int ID { get; set; }

        public int IDClass { get; set; }
        public string NameClass { get; set; }

        public int IDTeacher { get; set; }
        public string Nameteacher { get; set; }

        public int session { get; set; }

       // [Column(TypeName = "date")]
       [DataType(DataType.Date)]
       [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime Day { get; set; }

        public int? State { get; set; }
        
    }
}
