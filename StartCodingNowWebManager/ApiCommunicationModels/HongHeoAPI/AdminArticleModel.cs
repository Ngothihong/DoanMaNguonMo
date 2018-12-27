using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.FF;
using System.Runtime.Serialization;

namespace StartCodingNowWebManager.ApiCommunicationModels.HongHeoAPI
{
    [DataContract]
    public class AdminArticleModel
    {
        [DataMember(Name = "Idadmin")]
        public string Idadmin { get; set; }

        [DataMember(Name = "Pass")]
        public string Pass { get; set; }

        [DataMember(Name = "Status")]
        public int? Status { get; set; }

    }
}
