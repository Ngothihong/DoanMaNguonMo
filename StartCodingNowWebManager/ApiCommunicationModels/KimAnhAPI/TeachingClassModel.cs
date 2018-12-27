using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI
{
    public class TeachingClassModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Idclass")]
        public int Idclass { get; set; }

        [DataMember(Name = "NameClass")]
        public string NameClass { get; set; }

        [DataMember(Name = "Idteacher")]
        public int Idteacher { get; set; }

        [DataMember(Name = "Nameteacher")]
        public string Nameteacher { get; set; }

        [DataMember(Name = "Session")]
        public int Session { get; set; }

        [DataMember(Name = "Day")]
        public DateTime Day { get; set; }

        [DataMember(Name = "State")]
        public int? State { get; set; }
    }
}
