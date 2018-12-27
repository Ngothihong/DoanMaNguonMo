using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI
{
    public class RegistrationCourseModel
    {
        [DataMember(Name = "Idregist")]
        public int Idregist { get; set; }

        [DataMember(Name = "NameParent")]
        public string NameParent { get; set; }

        [DataMember(Name = "Phone")]
        public string Phone { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "NameStudent")]
        public string NameStudent { get; set; }

        [DataMember(Name = "Birthday")]
        public DateTime? Birthday { get; set; }

        [DataMember(Name = "Address")]
        public string Address { get; set; }

        [DataMember(Name = "Idcourse")]
        public string Idcourse { get; set; }

        [DataMember(Name = "State")]
        public string State { get; set; }
    }
}
