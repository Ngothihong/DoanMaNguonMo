using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI
{
    public class TeacherModel
    {
        [DataMember(Name = "Idteacher")]
        public int Idteacher { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Sex")]
        public string Sex { get; set; }

        [DataMember(Name = "Phone")]
        public string Phone { get; set; }

        [DataMember(Name = "Address")]
        public string Address { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "Knowledge")]
        public string Knowledge { get; set; }

        [DataMember(Name = "Status")]
        public int? Status { get; set; }
    }
}
