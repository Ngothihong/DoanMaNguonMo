using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.FF;
using System.Runtime.Serialization;

namespace StartCodingNowWebManager.ApiCommunicationModels.HongHeoAPI
{
    [DataContract]
    public class ArticleModel
    {
        [DataMember(Name = "IdArticle")]
        public int IdArticle { get; set; }

        [DataMember(Name = "Title")]
        public string Title { get; set; }

        [DataMember(Name = "Summary")]
        public string Summary { get; set; }

        [DataMember(Name = "Contents")]
        public string Contents { get; set; }

        [DataMember(Name = "Image")]
        public string Image { get; set; }

        [DataMember(Name = "Day")]
        public DateTime? Day { get; set; }

        [DataMember(Name = "Idadmin")]
        public string Idadmin { get; set; }

        [DataMember(Name = "State")]
        public int? State { get; set; }

        [DataMember(Name = "IdMenu")]
        public int IdMenu { get; set; }

    }
}
