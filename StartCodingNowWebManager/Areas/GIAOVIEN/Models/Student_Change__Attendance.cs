using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StartCodingNowWebManager.Areas.GIAOVIEN.Models
{
    public class Student_Change__Attendance
    {
       
        [Column(Order = 0)]
        [StringLength(20)]
        public int IDClass { get; set; }
       
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDStudent { get; set; }

        [Column(TypeName = "date")]
        public string NameStudent { get; set; }

        public bool[] state = new bool[12]; /*{0,0,0 ,0 ,0,0,0,0,0,0,0,0 }; */
        

    }
}