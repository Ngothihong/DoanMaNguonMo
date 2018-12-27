using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StartCodingNowWebManager.Areas.GIAOVIEN.Models
{
    public class Class_model
    {
        [System.ComponentModel.DataAnnotations.Key]
        [StringLength(20)]
        public int IDClass { get; set; }

        [Required]
        [StringLength(20)]
        public string NameCourse { get; set; }

        [StringLength(100)]
        public string NameClass { get; set; }


        [Column(TypeName = "date")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDay { get; set; }


        [Column(TypeName = "date")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FinishDay { get; set; }

        public int? Number { get; set; }

        public int? State { get; set; }
    }
}