using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI
{
    public class ClassModel
    {
        [DataMember(Name = "Idclass")]
        public int Idclass { get; set; }

        [DataMember(Name = "Idcourse")]
        public string Idcourse { get; set; }

        [DataMember(Name = "NameClass")]
        public string NameClass { get; set; }

        [DataMember(Name = "NameCourse")]
        public string NameCourse { get; set; }

        [DataMember(Name = "StartDay")]
        public DateTime? StartDay { get; set; }

        [DataMember(Name = "FinishDay")]
        public DateTime? FinishDay { get; set; }

        [DataMember(Name = "Number")]
        public int? Number { get; set; }

        [DataMember(Name = "State")]
        public int? State { get; set; }
    }
}
