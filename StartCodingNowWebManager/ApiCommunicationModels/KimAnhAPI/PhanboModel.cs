using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI
{
    public class PhanboModel
    {

        [DataMember(Name = "Idclass")]
        public int Idclass { get; set; }


        [DataMember(Name = "Idteacher")]
        public int Idteacher { get; set; }

        [DataMember(Name = "NameCourse")]
        public string NameCourse { get; set; }

        [DataMember(Name = "NameClass")]
        [StringLength(100)]
        public string NameClass { get; set; }

        [DataMember(Name = "NameTeacher")]
        public string NameTeacher { get; set; }

        [DataMember(Name = "StartDay")]
        [Column(TypeName = "date")]
        public DateTime? StartDay { get; set; }

        [DataMember(Name = "FinishDay")]
        [Column(TypeName = "date")]
        public DateTime? FinishDay { get; set; }

        [DataMember(Name = "Number")]

        public int? Number { get; set; }

        [DataMember(Name = "State")]
        public int? State { get; set; }
    }
}
