using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI
{
    public class CourseModel
    {
        [DataMember(Name = "Idcourse")]
        public string Idcourse { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Age")]
        public int Age { get; set; }

        [DataMember(Name = "Maxnumber")]
        public int? Maxnumber { get; set; }

        [DataMember(Name = "Time")]
        public string Time { get; set; }

        [DataMember(Name = "Contents")]
        public string Contents { get; set; }

        [DataMember(Name = "Fee")]
        public decimal? Fee { get; set; }

        [DataMember(Name = "Image")]
        public string Image { get; set; }

    }
}
