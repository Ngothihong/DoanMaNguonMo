using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StartCodingNowWebManager.Areas.GIAOVIEN.Models
{
    public class Student_Attendance
    {

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public int IDClass { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDStudent { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Session { get; set; }

        [Column(TypeName = "date")]
        public string NameStudent { get; set; }


        [Column(TypeName = "date")]
        public DateTime Day { get; set; }

        public int? State { get; set; }

    }
}