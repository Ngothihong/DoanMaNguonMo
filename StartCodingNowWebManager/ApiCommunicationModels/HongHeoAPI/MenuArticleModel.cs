using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.FF;
using System.Runtime.Serialization;

namespace StartCodingNowWebManager.ApiCommunicationModels.HongHeoAPI
{
    [DataContract]
    public class MenuArticleModel
    {
        [DataMember(Name = "IdMenu")]
        public int IdMenu { get; set; }

        [DataMember(Name = "NameMenu")]
        public string NameMenu { get; set; }
       
       
    }
}
