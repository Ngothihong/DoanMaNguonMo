using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StartCodingNowWebManager.Areas.GIAOVIEN.Models
{
    public class Teacher_Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int IDClass { get; set; }


        public string NameClass { get; set; }

       
        public int IDTeacher { get; set; }

        
        public int session { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Day { get; set; }

        public int? State { get; set; }
    }
}