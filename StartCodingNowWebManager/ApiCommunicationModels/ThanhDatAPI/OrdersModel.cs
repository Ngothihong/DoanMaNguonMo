using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.FF;
using System.Runtime.Serialization;

namespace StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI
{
    [DataContract]
    public class OrdersModel
    {
        [DataMember(Name = "Idorders")]
        public int Idorders { get; set; }

        [DataMember(Name = "NameCustomer")]
        public string NameCustomer { get; set; }

        [DataMember(Name = "Phone")]
        public string Phone { get; set; }

        [DataMember(Name = "Address")]
        public string Address { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "NumberProduct")]
        public int NumberProduct { get; set; }

        [DataMember(Name = "Idpromotion")]
        public string Idpromotion { get; set; }

        [DataMember(Name = "PriceTotal")]
        public decimal PriceTotal { get; set; }

        [DataMember(Name = "Date")]
        public DateTime? Date { get; set; }

        [DataMember(Name = "Payment")]
        public string Payment { get; set; }

        [DataMember(Name = "Note")]
        public string Note { get; set; }

        [DataMember(Name = "State")]
        public int? State { get; set; }

        [DataMember(Name = "Verify")]
        public bool? Verify { get; set; }

    }
}
