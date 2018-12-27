using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.FF;
using System.Runtime.Serialization;

namespace StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI
{
    [DataContract]
    public class PromotionModel
    {
        [DataMember(Name = "Idpromotion")]
        public string Idpromotion { get; set; }

        [DataMember(Name = "Value")]
        public string Value { get; set; }

        [DataMember(Name = "ValidDay")]
        public DateTime? ValidDay { get; set; }

        [DataMember(Name = "State")]
        public int? State { get; set; }

       
       
    }
}
