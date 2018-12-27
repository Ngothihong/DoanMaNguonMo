using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using StartCodingNowWebManager.FF;
namespace StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI
{
    [DataContract]
    public class DetailOrdersModel
    {
        [DataMember(Name = "Idorders")]
        public int Idorders { get; set; }

        [DataMember(Name = "Idrobot")]
        public string Idrobot { get; set; }

        [DataMember(Name = "Number")]
        public int? Number { get; set; }

        [DataMember(Name = "Price")]
        public decimal? Price { get; set; }
       
      
    }
}
