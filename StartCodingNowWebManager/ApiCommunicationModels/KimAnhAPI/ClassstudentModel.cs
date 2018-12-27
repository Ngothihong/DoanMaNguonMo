using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI
{
    public class ClassstudentModel
    {
        [DataMember(Name = "Idclass")]
        public int Idclass { get; set; }


        [DataMember(Name = "Idstudent")]
        public int Idstudent { get; set; }


        [DataMember(Name = "Session")]
        public int Idcourse { get; set; }


        [DataMember(Name = "Day")]
        public DateTime? Day { get; set; }


        [DataMember(Name = "State")]
        public int? State { get; set; }
    }
}
