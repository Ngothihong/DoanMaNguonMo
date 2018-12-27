using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.FF;
using System.Runtime.Serialization;

namespace StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI
{
    [DataContract]
    public class ProductModel
    {
        [DataMember(Name = "Idrobot")]
        public string Idrobot { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Number")]
        public int? Number { get; set; }

        [DataMember(Name = "Price")]
        public decimal? Price { get; set; }

        [DataMember(Name = "Contents")]
        public string Contents { get; set; }

        [DataMember(Name = "State")]
        public int? State { get; set; }

        [DataMember(Name = "Image")]
        public string Image { get; set; }
      
    }
}
