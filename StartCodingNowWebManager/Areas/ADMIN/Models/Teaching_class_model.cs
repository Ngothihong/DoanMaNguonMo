using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StartCodingNowWebManager.Areas.ADMIN.Models
{
    public class Teaching_class_model
    {
       
        public int IDClass { get; set; }

        [Required]
        [StringLength(20)]
        public string NameCourse { get; set; }

        [StringLength(100)]
        public string NameClass { get; set; }

        public int IDteacher { get; set; }
        public string NameTeacher { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FinishDay { get; set; }

        public int? Number { get; set; }

        public int? State { get; set; }
    }
}